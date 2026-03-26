using Entidades;
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
    public partial class FormSucursales : Form
    {
        private readonly Controladora.Controladora control = Controladora.Controladora.Instancia;
        private Form menuPadre;

        public FormSucursales(Form Padre)
        {
            InitializeComponent();
            CargarSucursales();
            menuPadre = Padre;
        }

        private void CargarSucursales()
        {
            dgvSucursales.DataSource = null;

            var lista = control.ListarSucursales()
                .Select(s => new
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Direccion = s.Direccion
                })
                .ToList();

            dgvSucursales.DataSource = lista;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var suc = new Sucursal
            {
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text
            };

            var resultado = control.AgregarSucursal(suc);
            MessageBox.Show(resultado);

            txtNombre.Clear();
            txtDireccion.Clear();
            CargarSucursales();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSucursales.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una sucursal.");
                return;
            }

            int id = (int)dgvSucursales.CurrentRow.Cells["Id"].Value;
            var suc = control.ListarSucursales().FirstOrDefault(x => x.Id == id);

            var r = MessageBox.Show("¿Seguro que querés eliminar la sucursal?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                control.EliminarSucursal(suc);
                CargarSucursales();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            menuPadre.Show();
            this.Close();
        }
    }
}
