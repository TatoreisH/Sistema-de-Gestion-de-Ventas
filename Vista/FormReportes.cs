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
    public partial class FormReportes : Form
    {
        private Form menuPadre;

        public FormReportes(Form Padre)
        {
            InitializeComponent();
            menuPadre = Padre;
        }

        private void btnVentasSucursal_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource =
                Controladora.Controladora.Instancia.ReporteVentasPorSucursal();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            menuPadre.Show();
            this.Close();
        }

        private void btnEstadoClientes_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource =
                Controladora.Controladora.Instancia.EstadoCuentaClientes();
        }

        private void btnVentasProducto_Click(object sender, EventArgs e)
        {
            dgvReportes.DataSource =
                Controladora.Controladora.Instancia.ReporteVentasPorProducto();
        }

        private void btnVentasPorPeriodo_Click(object sender, EventArgs e)
        {
            var datos = Controladora.Controladora.Instancia
               .ReporteVentasPorPeriodo(dtpDesde.Value, dtpHasta.Value);

            dgvReportes.DataSource = datos;
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {

        }
    }
}

