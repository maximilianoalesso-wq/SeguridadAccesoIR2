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

namespace SeguridadAccessoB
{
    public partial class BuscarUsuarioForm : Form
    {
        private int _idUsuarioSeleccionado;
        public int IdUsuarioSeleccionado {
            get
            {
                return _idUsuarioSeleccionado;
            }
        } //readonly
        public BuscarUsuarioForm(List<Usuario> usuarios)
        {
            InitializeComponent();
            dataGridView1.DataSource = usuarios.Select(u => new {u.Id, u.Nombre, u.Email}).ToList();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int filaSel = dataGridView1.CurrentRow.Index;
            if (filaSel == -1) 
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Seguridad de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //acá abrá una fila seleccionada
            _idUsuarioSeleccionado = (int) dataGridView1.Rows[filaSel].Cells["ColId"].Value;
            this.DialogResult = DialogResult.OK;

        }
    }
}
