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
    public partial class FormVentas : Form
    {
        private Form menuPadre;

        public FormVentas(Form Padre)
        {
            InitializeComponent();
            menuPadre = Padre;
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            cmbClientes.DataSource = Controladora.Controladora.Instancia.ListarClientes().ToList();
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "Id";

            cmbSucursales.DataSource = Controladora.Controladora.Instancia.ListarSucursales().ToList();
            cmbSucursales.DisplayMember = "Nombre";
            cmbSucursales.ValueMember = "Id";
            cmbSucursales.SelectedIndex = -1;

            cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta", "Transferencia" });

            dgvProductos.DataSource = null;

            lblTotal.Text = "Total: $0";
        }

        private List<VentaDetalle> detalles = new List<VentaDetalle>();

        private void cmbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSucursales.SelectedValue is not int sucursalId) return;

            var lista = Controladora.Controladora.Instancia
                .ListarProductosPorSucursal(sucursalId)
                .Select(p => new
                {
                    p.CodigoProducto,
                    Nombre = p.Producto.Nombre,
                    Precio = p.Producto.Precio,
                    p.Stock
                }).ToList();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = lista;

            dgvProductos.Columns["CodigoProducto"].HeaderText = "Código";
            dgvProductos.Columns["Nombre"].HeaderText = "Producto";
            dgvProductos.Columns["Precio"].HeaderText = "Precio";
            dgvProductos.Columns["Stock"].HeaderText = "Stock";

            foreach (DataGridViewColumn col in dgvProductos.Columns)
            {
                if (col.Name != "CodigoProducto" &&
                    col.Name != "Nombre" &&
                    col.Name != "Precio" &&
                    col.Name != "Stock")
                {
                    col.Visible = false;
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            int codigoProducto = (int)dgvProductos.CurrentRow.Cells["CodigoProducto"].Value;
            var ps = Controladora.Controladora.Instancia.ListarProductosPorSucursal((int)cmbSucursales.SelectedValue)
                     .FirstOrDefault(p => p.CodigoProducto == codigoProducto);

            if (ps == null || ps.Stock <= 0)
            {
                MessageBox.Show("No hay stock disponible.");
                return;
            }

            // Pedimos cantidad
            string cantidadTxt = Microsoft.VisualBasic.Interaction.InputBox(
                $"Stock disponible: {ps.Stock}\nIngrese cantidad:",
                "Cantidad"
            );

            if (!int.TryParse(cantidadTxt, out int cantidad) || cantidad <= 0)
                return;

            if (cantidad > ps.Stock)
            {
                MessageBox.Show("No hay stock suficiente");
                return;
            }

            // Verificar si ya existe en detalles
            var detalleExistente = detalles.FirstOrDefault(d => d.CodigoProducto == ps.CodigoProducto);
            if (detalleExistente != null)
            {
                if (detalleExistente.Cantidad + cantidad > ps.Stock)
                {
                    MessageBox.Show("No hay stock suficiente para agregar más.");
                    return;
                }
                detalleExistente.Cantidad += cantidad;
                detalleExistente.Subtotal = detalleExistente.Cantidad * detalleExistente.PrecioUnitario;
            }
            else
            {
                detalles.Add(new VentaDetalle
                {
                    CodigoProducto = ps.CodigoProducto,
                    Producto = ps.Producto,
                    Cantidad = cantidad,
                    PrecioUnitario = ps.Producto.Precio,
                    Subtotal = cantidad * ps.Producto.Precio
                });
            }

            RefrescarDetalleVenta();
        }

        private void RefrescarDetalleVenta()
        {
            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.DataSource = detalles.Select(d => new
            {
                d.CodigoProducto,
                Producto = d.Producto.Nombre,
                d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                d.Subtotal
            }).ToList();

            decimal total = detalles.Sum(d => d.Subtotal);
            lblTotal.Text = $"Total: ${total}";
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (detalles.Count == 0)
            {
                MessageBox.Show("Agregá al menos un producto.");
                return;
            }

            var venta = new Venta
            {
                Fecha = DateTime.Now,
                ClienteId = int.Parse(cmbClientes.SelectedValue?.ToString() ?? "0"),
                SucursalId = int.Parse(cmbSucursales.SelectedValue?.ToString() ?? "0"),
                MetodoPago = cmbMetodoPago.Text,
                Detalles = detalles
            };

            if (cmbSucursales.SelectedValue == null || (int)cmbSucursales.SelectedValue == 0)
            {
                MessageBox.Show("Seleccioná una sucursal válida.");
                return;
            }

            string resultado = Controladora.Controladora.Instancia.RegistrarVenta(venta);
            MessageBox.Show(resultado);

            // Generar y mostrar factura
            string factura = Controladora.Controladora.Instancia.GenerarFactura(venta);
            MessageBox.Show(factura, "Factura");

            // Limpiar todo
            detalles.Clear();
            dgvDetalleVenta.DataSource = null;
            lblTotal.Text = "Total: $0";

            // Actualizar stock visible
            cmbSucursales_SelectedIndexChanged(null, null);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            menuPadre.Show();
            this.Close();
        }
    }
}
