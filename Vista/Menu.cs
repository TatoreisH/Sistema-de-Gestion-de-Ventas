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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            FormProductos frmProductos = new FormProductos(this);
            this.Hide();
            frmProductos.Show();
        }


        private void btnCliente_Click(object sender, EventArgs e)
        {
            FormClientes frmClientes = new FormClientes(this);
            this.Hide();
            frmClientes.Show();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FormCategorias frmCategorias = new FormCategorias(this);
            this.Hide();
            frmCategorias.Show();
        }

        private void btnSucursal_Click(object sender, EventArgs e)
        {
            FormSucursales frmSucursales = new FormSucursales(this);
            this.Hide();
            frmSucursales.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormReportes frmReportes = new FormReportes(this);
            this.Hide();
            frmReportes.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FormVentas frmVentas = new FormVentas(this);
            this.Hide();
            frmVentas.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
