using LectorHuellaZKTeco;
using SeguridadAccessoB.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguridadAccessoB
{
    public partial class UCIdentificar : UserControl
    {
        private RepUsuarios _repUsuario = new RepUsuarios();
        private bool _lectorInicializado = false;
        private Usuario _usuario;
        private string _puerto = "";
        Timer _timerContador = new Timer();
        private int _contador = 8;
        Timer _timerCapturando = new Timer();
        Timer _timerHuella = new Timer();
        int anchoOrig;
        int altoOrig;
        float radianes = 0;
        public UCIdentificar(string puerto)
        {
            InitializeComponent();
            anchoOrig = pbHuella.Width;
            altoOrig = pbHuella.Height;
            List<Usuario> usuarios = _repUsuario.GetAll();

            _timerContador.Interval = 1000;
            _timerContador.Tick += _timerContador_Tick;
            _timerCapturando.Interval = 500;
            _timerCapturando.Tick += _timerCapturando_Tick;
            _timerCapturando.Start();
            _timerHuella.Interval = 70;
            _timerHuella.Tick += _timerHuella_Tick;
            _timerHuella.Start();
            try
            {
                LectorHuella.Inicializar();
                _lectorInicializado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seguridad", ex.Message);
            }

            //Lector (eventos)
            LectorHuella.HuellaEscaneadaIdentificacionEvent += this.HuellaEscaneadaIdentificacion; // se dispara al identificar huella y envía id del usuario identificado
            LectorHuella.ErrorCapturaHuellaEvent += this.ErrorCapturaHuella; //se dispara al ocurrir cualquier error y envía como parámetro tipo string

            List<ElementoCache> listaUsuarioLector = new List<ElementoCache>();
            foreach (Usuario usuario in usuarios)
            {
                listaUsuarioLector.Add(new ElementoCache
                {
                    id = usuario.Id,
                    template = usuario.TemplateHuella
                });
            }
            LectorHuella.CargarCacheLector(listaUsuarioLector);
            LectorHuella.IniciarIdentificacion();
            _puerto = puerto;
            AbrirPuerto();
        }

        private void _timerHuella_Tick(object sender, EventArgs e)
        {
            double inc = 1.0 + 0.03 * Math.Sin(radianes * Math.PI / 10);
            //calcular nuevo ancho
            double nuevoAncho = (double)anchoOrig;
            pbHuella.Width = (int)(nuevoAncho * inc);
            int x = (anchoOrig - pbHuella.Width) / 2;
            //calcular nuevo alto
            double nuevoAlto = (double)altoOrig;
            pbHuella.Height = (int)(nuevoAlto * inc);
            int y = (altoOrig - pbHuella.Height) / 2;
            pbHuella.Location = new Point(x, y);
            radianes++;
            if (radianes >= 20)
                radianes = 0;
        }

        private void _timerCapturando_Tick(object sender, EventArgs e)
        {
            if (lbTitulo.Text.StartsWith("CAPTURANDO"))
            {
                char[] titulo = lbTitulo.Text.ToCharArray();
                char[] puntos = titulo.Where(x => x == '.').ToArray();
                if (puntos.Length == 3)
                {
                    lbTitulo.Text = "CAPTURANDO";
                }
                else
                {
                    lbTitulo.Text = lbTitulo.Text + ".";
                }
            } 

             
        }
        private void _timerContador_Tick(object sender, EventArgs e)
        {
            _contador--;
            if (_contador <= 0)
            {
                _contador = 8;
                lbTitulo.Text = "CAPTURANDO";
                lbNombre.Text = "";
                PuertoArduino.WriteLine("close");
                _timerContador.Stop();
                lbTemp.Text = "";
            }
            else
            {
                lbTemp.Text = _contador.ToString(); 
            }
        }
        public void FinalizarLectorHuella()
        {
            LectorHuella.HuellaEscaneadaIdentificacionEvent -= this.HuellaEscaneadaIdentificacion; // se dispara al identificar huella y envía id del usuario identificado
            LectorHuella.ErrorCapturaHuellaEvent -= this.ErrorCapturaHuella; //se dispara al ocurrir cualquier error y envía como parámetro tipo string
            LectorHuella.Finalizar();
        }

        void AbrirPuerto()
        {
            PuertoArduino = new SerialPort(_puerto);
            PuertoArduino.BaudRate = 9600;
            PuertoArduino.Parity = Parity.None;
            PuertoArduino.StopBits = StopBits.One;
            PuertoArduino.DataBits = 8;
            PuertoArduino.Handshake = Handshake.None;
            PuertoArduino.RtsEnable = true;

            try
            {
                PuertoArduino.Open();
            }
            catch
            {
                MessageBox.Show("Error al abrir el puerto.", "Seguridad de Acceso");
            }

        }
        private void ErrorCapturaHuella(string msjError)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep_error.wav");
            player.Play();
            lbTitulo.Text = "ACCESO DENEGADO";
            lbNombre.Text = "";
            System.Threading.Thread.Sleep(3000);
            lbTitulo.Text = "CAPTURANDO";
        }
        private void HuellaEscaneadaIdentificacion(int id)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep1.wav");
            player.Play();
            if (id == -1)
            {
                Action mostrar = MostrarAccesoDenegado;
                this.Invoke(mostrar);
                return;
            }
            _usuario = _repUsuario.GetByID(id);
            Action abrirPorton = AbrirPorton;
            this.Invoke(abrirPorton);            
        }

        void MostrarAccesoDenegado()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep_error.wav");
            player.Play();
            lbTitulo.Text = "ACCESO DENEGADO";
            lbNombre.Text = "";
            Application.DoEvents();
            System.Threading.Thread.Sleep(3000);
            lbTitulo.Text = "CAPTURANDO";
        }
        private void AbrirPorton()
        {
            if (PuertoArduino.IsOpen)
            {
                lbTitulo.Text = "ACCESO CONCEDIDO!";
                lbNombre.Text = _usuario.Nombre;
                PuertoArduino.WriteLine("open");
                _timerContador.Start();
            }
        }
    }
}