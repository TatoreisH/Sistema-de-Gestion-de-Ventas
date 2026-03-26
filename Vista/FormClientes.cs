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
    public partial class FormClientes : Form
    {
        private Form menuPadre;

        public FormClientes(Form padre)
        {
            InitializeComponent();
            menuPadre = padre;
            CargarClientes();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = null;

            var clientes = Controladora.Controladora.Instancia.ListarClientes();

            var listaLimpia = clientes.Select(c => new
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Tipo = c.Tipo,
                Email = c.Email,
                Telefono = c.Telefono
                // NO incluimos c.Ventas
            }).ToList();

            dgvClientes.DataSource = listaLimpia;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            c.Nombre = txtNombre.Text;
            c.Tipo = cmbTipo.Text;
            c.Email = txtMail.Text;

            if (!long.TryParse(txtTelefono.Text, out long tel))
            {
                MessageBox.Show("Teléfono inválido.");
                return;
            }

            c.Telefono = tel;

            string resultado = Controladora.Controladora.Instancia.AgregarCliente(c);
            MessageBox.Show(resultado);

            CargarClientes();
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = (int)dgvClientes.CurrentRow.Cells["Id"].Value;


            Cliente c = Controladora.Controladora.Instancia.ListarClientes().FirstOrDefault(x => x.Id == id);

            if (c == null) return;

            c.Nombre = txtNombre.Text;
            c.Tipo = cmbTipo.Text;
            c.Email = txtMail.Text;

            if (!long.TryParse(txtTelefono.Text, out long tel))
            {
                MessageBox.Show("Teléfono inválido.");
                return;
            }

            c.Telefono = tel;

            string resultado = Controladora.Controladora.Instancia.ModificarCliente(c);
            MessageBox.Show(resultado);

            CargarClientes();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = (int)dgvClientes.CurrentRow.Cells["Id"].Value;

            Cliente c = Controladora.Controladora.Instancia.ListarClientes().FirstOrDefault(x => x.Id == id);

            if (c == null) return;

            var confirm = MessageBox.Show(
                "¿Seguro que querés eliminar este cliente?",
                "Confirmar",
                MessageBoxButtons.YesNo
            );

            if (confirm == DialogResult.Yes)
            {
                string resultado = Controladora.Controladora.Instancia.EliminarCliente(c);
                MessageBox.Show(resultado);
                CargarClientes();
                LimpiarCampos();
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = (int)dgvClientes.Rows[e.RowIndex].Cells["Id"].Value;

            Cliente c = Controladora.Controladora.Instancia.ListarClientes().FirstOrDefault(x => x.Id == id);

            if (c == null) return;

            txtNombre.Text = c.Nombre;
            cmbTipo.Text = c.Tipo;
            txtMail.Text = c.Email;
            txtTelefono.Text = c.Telefono.ToString();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            cmbTipo.SelectedIndex = -1;
            txtMail.Clear();
            txtTelefono.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            menuPadre.Show();
            this.Close();
        }
    }
}
