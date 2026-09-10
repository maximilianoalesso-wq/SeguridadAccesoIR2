using SeguridadAccessoB.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SeguridadAccessoB.Repositorio;
using System.Net.NetworkInformation;
using LectorHuellaZKTeco;

namespace SeguridadAccessoB
{
    public partial class UCRegistrar : UserControl
    {
        private RepUsuarios _repUsuarios = new RepUsuarios();
        private Usuario _usuarioActual;
        private bool _lectorIniciado = false;
        private bool _lectorFinalizado = false;
        public UCRegistrar()
        {
            InitializeComponent();


            _deshabilitarForm();
            
            List<Usuario> usuarios = _repUsuarios.GetAll();

            try
            {
                LectorHuella.Inicializar();
                _lectorIniciado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seguridad", ex.Message);
            }

            //Lector (eventos)
            LectorHuella.HuellaEscaneadaRegistroEvent += this.HuellaEscaneadaRegistro; //se dispara al ir registran las tres capturas de una huella, envía un int indicando cuántas capturas faltan
            LectorHuella.HuellaCapturadaCorrectamenteRegistroEvent += HuellaCatpuradaCorrectamenteRegistro; //se dispara al registrar la huella correctamente luego de 3 capturas, aquí se debe tomar el template
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
            lbEstadoLector.Text = "Identificando...";

        }

        public void FinalizarLectorHuella()
        {
            LectorHuella.HuellaEscaneadaRegistroEvent -= this.HuellaEscaneadaRegistro; //se dispara al ir registran las tres capturas de una huella, envía un int indicando cuántas capturas faltan
            LectorHuella.HuellaCapturadaCorrectamenteRegistroEvent -= HuellaCatpuradaCorrectamenteRegistro; //se dispara al registrar la huella correctamente luego de 3 capturas, aquí se debe tomar el template
            LectorHuella.HuellaEscaneadaIdentificacionEvent -= this.HuellaEscaneadaIdentificacion; // se dispara al identificar huella y envía id del usuario identificado
            LectorHuella.ErrorCapturaHuellaEvent -= this.ErrorCapturaHuella; //se dispara al ocurrir cualquier error y envía como parámetro tipo string
            LectorHuella.Finalizar();
        }
        private void ErrorCapturaHuella(string msjError)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep_error.wav");
            player.Play();
            MessageBox.Show("Seguridad", msjError);
            _deshabilitarForm();
            _limpiarForm();
            LectorHuella.IniciarIdentificacion();
            lbEstadoLector.Text = "Identificando...";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _usuarioActual = new Usuario();
            _habilitarForm();
            _limpiarForm(); 
            LectorHuella.IniciarRegistro();
            lbEstadoLector.Text = "Registrando...";
        }

        //cuando captura la 1 y 2da vez
        private void HuellaEscaneadaRegistro(int faltan)
        {
            Action<string> fnEstado = _setEstadoLector;
            this.Invoke(fnEstado, "Faltan " + faltan.ToString() + " muestras...");
            pbHuella.Image = LectorHuella.GetImagenHuella();
            //sonido
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep1.wav");
            player.Play();

        }

        //cuando captura la 3er y ultima vez
        private void HuellaCatpuradaCorrectamenteRegistro(string mensaje)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep2.wav");
            player.Play();
            Action<string> fnEstado = _setEstadoLector;
            this.Invoke(fnEstado, "");
            pbHuella.Image = LectorHuella.GetImagenHuella();
            _usuarioActual.TemplateHuella = LectorHuella.GetTemplateHuellaBase64();
            Action<bool> fnCheck = _setCheckHuella;
            this.Invoke(fnCheck, true);

        }

        private void HuellaEscaneadaIdentificacion(int id)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep1.wav");
            player.Play();
            _usuarioActual = _repUsuarios.GetByID(id);
            Action fnRellenar = _rellenarForm;
            this.Invoke(fnRellenar);
            Action fnHabilitar = _habilitarForm;
            this.Invoke(fnHabilitar);

        }
        private void _setCheckHuella(bool valor)
        {
            cbHuellaRegistrada.Checked = valor;
        }
        private void _setEstadoLector(string msj)
        {
            lbMensajes.Text = msj;
        }
        private void _habilitarForm()
        {
            txtNombre.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
        }
        private void _deshabilitarForm()
        {
            txtNombre.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
        }
        private void _limpiarForm()
        {
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            cbHuellaRegistrada.Checked = false;
            pbHuella.Image = null;  
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!cbHuellaRegistrada.Checked || txtNombre.Text.Trim() == "" || txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Seguridad", "Debe ingresar un nombre, un correo y la muestra de su huella digital");
                return;
            }
            _usuarioActual.Nombre = txtNombre.Text.Trim();
            _usuarioActual.Email = txtEmail.Text.Trim();
            _usuarioActual.Telefono = txtTelefono.Text.Trim();
            if (_usuarioActual.Id == 0) //usuario nuevo
            {
                _repUsuarios.Post(_usuarioActual);
                MessageBox.Show("Usuario creado correctametne.", "Seguridad de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _deshabilitarForm();
                _limpiarForm();

                ElementoCache elementoCache = new ElementoCache();
                elementoCache.id = _usuarioActual.Id;
                elementoCache.template = _usuarioActual.TemplateHuella;

                LectorHuella.AgregarACacheLector(elementoCache);
            }
            else 
            {
                _repUsuarios.Put(_usuarioActual);
                MessageBox.Show("Usuario actualizado correctametne.", "Seguridad de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _deshabilitarForm();
                _limpiarForm();
            }
            LectorHuella.IniciarIdentificacion();
            lbEstadoLector.Text = "Identificando...";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarUsuarioForm ventBuscar = new BuscarUsuarioForm(_repUsuarios.GetAll());
            DialogResult res;
            int idUsuarioSel;
            res = ventBuscar.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                return;
            }
            //se cerró la ventana buscar con OK
            idUsuarioSel = ventBuscar.IdUsuarioSeleccionado;
            _usuarioActual = _repUsuarios.GetByID(idUsuarioSel);
            _rellenarForm();
            _habilitarForm();
        }

        private void _rellenarForm()
        {
            txtNombre.Text = _usuarioActual.Nombre;
            txtEmail.Text = _usuarioActual.Email;
            txtTelefono.Text = _usuarioActual.Telefono;
            cbHuellaRegistrada.Checked = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _repUsuarios.Delete(_usuarioActual);
            MessageBox.Show("Usuario eliminado correctamente.", "Seguridad de Acceso");
            _limpiarForm();
            _deshabilitarForm();
        }
    }
}
