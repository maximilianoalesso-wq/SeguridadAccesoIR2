using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguridadAccessoB
{
    public partial class MenuPrincipal : Form
    {
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
            //BuscarUsuarioForm miForm = new BuscarUsuarioForm();
            //miForm.ShowDialog();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            UCRegistrar uCRegistrar = new UCRegistrar();
            panelPrincipal.Controls.Clear();    
            panelPrincipal.Controls.Add(uCRegistrar);
        }
    }
}
