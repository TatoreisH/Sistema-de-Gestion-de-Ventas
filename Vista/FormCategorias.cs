using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormCategorias : Form
    {
        private Form menuPadre;
        public FormCategorias(Form padre)
        {
            InitializeComponent();
            menuPadre = padre;
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = Controladora.Controladora.Instancia.ListarCategorias();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria c = new Categoria()
            {
                Nombre = txtNombreCategoria.Text
            };

            string resultado = Controladora.Controladora.Instancia.AgregarCategoria(c);
            MessageBox.Show(resultado);
            CargarCategorias();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            menuPadre.Show();
            this.Close();
        }
    }
}
