using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguridadAccessoB
{
    public partial class UCAjustes : UserControl
    {
        private MenuPrincipal _menuPpal;
        public UCAjustes(MenuPrincipal mp)
        {
            InitializeComponent();
            _menuPpal = mp;
            foreach (string puerto in SerialPort.GetPortNames())
            {
                cbPuertos.Items.Add(puerto);
            }
            if (cbPuertos.Items.Count > 0)
            {

                cbPuertos.SelectedIndex = 0;
            }
        }

        ~UCAjustes()
        {
            if (PuertoArduino.IsOpen) {
                PuertoArduino.Close();
             }
        }


        private void UCAjustes_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            lbPuertoSel.Text = cbPuertos.SelectedItem.ToString();
            _menuPpal.PuertoArduino = cbPuertos.SelectedItem.ToString();
        }

        private void btnAbrirPuerto_Click(object sender, EventArgs e)
        {
            PuertoArduino = new SerialPort(cbPuertos.SelectedItem.ToString());
            PuertoArduino.BaudRate = 9600;
            PuertoArduino.Parity = Parity.None;
            PuertoArduino.StopBits = StopBits.One;
            PuertoArduino.DataBits = 8;
            PuertoArduino.Handshake = Handshake.None;
            PuertoArduino.RtsEnable = true;

            try
            {
                PuertoArduino.Open();
                lbEstadoPuerto.Text = "Abierto";
            }
            catch 
            {
                MessageBox.Show("Error al abrir el puerto.", "Seguridad de Acceso");
            }
        }

        private void btnCerrarPuerto_Click(object sender, EventArgs e)
        {
            if (PuertoArduino.IsOpen)
            {
                PuertoArduino.Close();
                lbEstadoPuerto.Text = "Cerrado";
            }
        }

        private void btnAbrirPorton_Click(object sender, EventArgs e)
        {
            if (PuertoArduino.IsOpen)
            {
                PuertoArduino.WriteLine("open");
            }
            else
            {
                MessageBox.Show("Puerto cerrado.");
            }

        }

        private void btnCerrarPorton_Click(object sender, EventArgs e)
        {
            if (PuertoArduino.IsOpen)
            {
                PuertoArduino.WriteLine("close");
            }
            else
            {
                MessageBox.Show("Puerto cerrado.");
            }
        }
    }
}
