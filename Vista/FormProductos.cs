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
    public partial class FormProductos : Form
    {
        private Form menuPadre;

        private Producto productoSeleccionado;
        public FormProductos(Form padre)
        {
            InitializeComponent();
            menuPadre = padre;
            CargarProductos();
            CargarCategorias();
            CargarStockSucursal();
            CargarProductosCombo();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = null;

            var productos = Controladora.Controladora.Instancia.ListarProductos();
            var categorias = Controladora.Controladora.Instancia.ListarCategorias();

            var listaLimpia = productos.Select(p => new
            {
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Categoria = categorias.FirstOrDefault(c => c.Id == p.CategoriaId)?.Nombre
            }).ToList();

            dgvProductos.DataSource = listaLimpia;
        }

        private void CargarProductosCombo()
        {
            var productos = Controladora.Controladora.Instancia.ListarProductos();
            cmbProductosStock.DataSource = productos.ToList();
            cmbProductosStock.DisplayMember = "Nombre"; 
            cmbProductosStock.ValueMember = "Codigo";   
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            var sucursales = Controladora.Controladora.Instancia.ListarSucursales();
            cmbSucursal.DataSource = sucursales.ToList();
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto()
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                CategoriaId = (int)cmbCategoria.SelectedValue,
                Precio = decimal.Parse(txtPrecio.Text)

            };

            string resultado = Controladora.Controladora.Instancia.AgregarProducto(p);
            MessageBox.Show(resultado);
            CargarProductos();
            CargarStockSucursal();
            CargarProductosCombo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }
            productoSeleccionado.Nombre = txtNombre.Text;
            productoSeleccionado.Descripcion = txtDescripcion.Text;
            productoSeleccionado.Precio = decimal.Parse(txtPrecio.Text);
            productoSeleccionado.CategoriaId = (int)cmbCategoria.SelectedValue;

            string resultado = Controladora.Controladora.Instancia.ModificarProducto(productoSeleccionado);
            MessageBox.Show(resultado);
            CargarProductos();
            CargarStockSucursal();
            CargarProductosCombo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            string resultado = Controladora.Controladora.Instancia.EliminarProducto(productoSeleccionado);
            MessageBox.Show(resultado);
            CargarProductos();
            CargarStockSucursal();
            CargarProductosCombo();
        }

        private void ddgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int codigo = (int)dgvProductos.Rows[e.RowIndex].Cells["Codigo"].Value;

            productoSeleccionado = Controladora.Controladora.Instancia.ListarProductos().FirstOrDefault(p => p.Codigo == codigo);

            txtNombre.Text = productoSeleccionado.Nombre;
            txtDescripcion.Text = productoSeleccionado.Descripcion;
            txtPrecio.Text = productoSeleccionado.Precio.ToString();

            cmbCategoria.SelectedValue = productoSeleccionado.CategoriaId;
        }

        private void CargarCategorias()
        {
            var categorias = Controladora.Controladora.Instancia.ListarCategorias();

            cmbCategoria.DataSource = categorias.ToList();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            menuPadre.Show();
            this.Close();
        }

        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            if (cmbProductosStock.SelectedValue is not int codigoProducto)
            {
                MessageBox.Show("Selecciona un producto válido.");
                return;
            }

            if (!int.TryParse(txtCantidadStock.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingresa una cantidad válida.");
                return;
            }

            if (cmbSucursal.SelectedValue is not int sucursalId)
            {
                MessageBox.Show("Selecciona una sucursal válida.");
                return;
            }

            var producto = Controladora.Controladora.Instancia.ListarProductos()
                             .FirstOrDefault(p => p.Codigo == codigoProducto);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            var ps = new ProductoSucursal
            {
                CodigoProducto = producto.Codigo,
                Producto = producto,
                SucursalId = sucursalId,
                Stock = cantidad
            };

            string resultado = Controladora.Controladora.Instancia.AgregarOActualizarStock(ps);
            MessageBox.Show(resultado);

            txtCantidadStock.Clear();
            CargarStockSucursal();
        }

        private void CargarStockSucursal()
        {
            if (cmbSucursal.SelectedValue is not int sucursalId) return;

            var stock = Controladora.Controladora.Instancia.ListarProductosPorSucursal(sucursalId);

            dgvStock.DataSource = stock
                .Select(ps => new
                {
                    CodigoProducto = ps.CodigoProducto,
                    Producto = ps.Producto.Nombre,
                    Sucursal = ps.Sucursal.Nombre,
                    Stock = ps.Stock
                })
                .ToList();
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarStockSucursal();
        }
    }
}
