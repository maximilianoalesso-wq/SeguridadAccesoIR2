using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguridadAccessoB
{
    public partial class MenuPrincipal : Form
    {

        private string _puertoArduino;
        

        public string PuertoArduino {
            get 
            {
                return _puertoArduino;
            } 
            set 
            {
                _puertoArduino = value;
                slPuerto.Text = _puertoArduino;
            }
        }

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("¿Está seguro que desea abandonar la aplicación?", "Control de Acceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("¿Está seguro que desea abandonar la aplicación?", "Control de Acceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.No)
            {
                e.Cancel = true; //cancelar el evento de cierre
            }
            
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            UCAjustes uCAjustes = new UCAjustes(this);
            int x = (this.Width - uCAjustes.Width) / 2;
            int y = (this.Height - uCAjustes.Height) / 2;
            uCAjustes.Location = new Point(x, y);
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(uCAjustes);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FinalizarLectorHuella();
            UCRegistrar uCRegistrar = new UCRegistrar();
            int x = (this.Width - uCRegistrar.Width) / 2;
            int y = (this.Height - uCRegistrar.Height) / 2;
            uCRegistrar.Location = new Point(x, y);
            panelPrincipal.Controls.Clear();    
            panelPrincipal.Controls.Add(uCRegistrar);
        }

        void FinalizarLectorHuella()
        {
            UserControl uc;
            if (panelPrincipal.Controls.Count > 0)
            {
                uc = (UserControl)panelPrincipal.Controls[0];
                if (uc is UCIdentificar)
                {
                    UCIdentificar uci = (UCIdentificar)uc;
                    uci.FinalizarLectorHuella();
                }
                if (uc is UCRegistrar)
                {
                    UCRegistrar ucr = (UCRegistrar)uc;
                    ucr.FinalizarLectorHuella();
                }
            }
        }

        private void btnIdentificar_Click(object sender, EventArgs e)
        {
            FinalizarLectorHuella();
            UCIdentificar uCRegistrar = new UCIdentificar(_puertoArduino);
            int x = (this.Width - uCRegistrar.Width) / 2;
            int y = (this.Height - uCRegistrar.Height) / 2;
            uCRegistrar.Location = new Point(x, y);
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(uCRegistrar);
        }

        private void MenuPrincipal_Resize(object sender, EventArgs e)
        {
            if (panelPrincipal.Controls.Count > 0)
            {
                UserControl uc = (UserControl) panelPrincipal.Controls[0];
                int x = (this.Width - uc.Width) / 2;
                int y = (this.Height - uc.Height) / 2;
                uc.Location = new Point(x, y);
            }

        }
    }
}
