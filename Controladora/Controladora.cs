using Entidades;
using Modelo;
using System.Text;

namespace Controladora
{
    public class Controladora
    {
        private readonly Repositorio repositorio = new Repositorio();
        private static Controladora instancia;

        private Controladora() { }

        public static Controladora Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Controladora();
                return instancia;
            }
        }

        // ---------- PRODUCTOS ----------
        public IReadOnlyCollection<Producto> ListarProductos()
            => repositorio.ListarProductos();

        public string AgregarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                return "Código (entero) y nombre son obligatorios.";

            if (repositorio.BuscarProductoCodigo(producto.Codigo) != null)
                return "Ya existe un producto con ese código.";

            if (repositorio.BuscarProductoNombre(producto.Nombre) != null)
                return "Ya existe un producto con ese nombre.";

            repositorio.AgregarProducto(producto);
            return "Producto agregado correctamente.";
        }

        public string ModificarProducto(Producto producto)
        {
            repositorio.ModificarProducto(producto);
            return "Producto modificado correctamente.";
        }

        public string EliminarProducto(Producto producto)
        {
            repositorio.EliminarProducto(producto);
            return "Producto eliminado.";
        }

        // ---------- CATEGORIAS ----------
        public IReadOnlyCollection<Categoria> ListarCategorias() => repositorio.ListarCategorias();

        public string AgregarCategoria(Categoria cat)
        {
            if (string.IsNullOrWhiteSpace(cat.Nombre))
                return "Nombre de categoría requerido.";

            if (repositorio.BuscarCategoriaPorNombre(cat.Nombre) != null)
                return "Ya existe una categoría con ese nombre.";

            repositorio.AgregarCategoria(cat);
            return "Categoría agregada.";
        }

        // ---------- SUCURSALES ----------
        public IReadOnlyCollection<Sucursal> ListarSucursales() => repositorio.ListarSucursales();

        public string AgregarSucursal(Sucursal s)
        {
            if (string.IsNullOrWhiteSpace(s.Nombre))
                return "El nombre es obligatorio.";

            if (repositorio.BuscarSucursalPorNombre(s.Nombre) != null)
                return "Ya existe una sucursal con ese nombre.";

            if (string.IsNullOrWhiteSpace(s.Direccion))
                return "La dirección es obligatoria.";

            repositorio.AgregarSucursal(s);
            return "Sucursal agregada correctamente.";
        }

        public void EliminarSucursal(Sucursal suc)
        {
            repositorio.EliminarSucursal(suc);
        }

        // ---------- Productos Sucursal (STOCK) ----------
        public IReadOnlyCollection<ProductoSucursal> ListarProductosPorSucursal(int sucursalId)
            => repositorio.ListarProductosPorSucursal(sucursalId);

        public string AgregarOActualizarStock(ProductoSucursal ps)
        {
            if (ps == null || ps.CodigoProducto <= 0)
                return "Datos inválidos.";

            var productosSucursal = ListarProductosPorSucursal(ps.SucursalId);
            var existente = productosSucursal.FirstOrDefault(p => p.CodigoProducto == ps.CodigoProducto);

            if (existente != null)
            {
                existente.Stock += ps.Stock;
                repositorio.AgregarOActualizarProductoSucursal(existente);
            }
            else
            {
                repositorio.AgregarOActualizarProductoSucursal(ps);
            }

            return "Stock actualizado correctamente.";
        }

        // ---------- CLIENTES ----------
        public IReadOnlyCollection<Cliente> ListarClientes() => repositorio.ListarClientes();

        public string AgregarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                return "Nombre requerido.";

            if (repositorio.ListarClientes().Any(c => c.Nombre.Trim().ToLower() == cliente.Nombre.Trim().ToLower()))
                return "Ya existe un cliente con ese nombre.";

            if (string.IsNullOrWhiteSpace(cliente.Email))
                return "El email es obligatorio.";

            if (!cliente.Email.Contains('@') || !cliente.Email.Contains('.'))
                return "Email inválido.";

            if (cliente.Telefono <= 0)
                return "Teléfono inválido.";

            if (repositorio.ListarClientes().Any(c => c.Telefono == cliente.Telefono))
                return "Ya existe un cliente con ese teléfono.";

            repositorio.AgregarCliente(cliente);
            return "Cliente agregado correctamente.";
        }

        public string ModificarCliente(Cliente cliente)
        {
            if (cliente.Id <= 0)
                return "Cliente inválido.";
            repositorio.ModificarCliente(cliente);
            return "Cliente actualizado.";
        }

        public string EliminarCliente(Cliente cliente)
        {
            repositorio.EliminarCliente(cliente);
            return "Cliente eliminado.";
        }

        // ---------- VENTAS ----------
        public string RegistrarVenta(Venta venta)
        {
            try
            {
                if (venta == null || venta.Detalles == null || !venta.Detalles.Any())
                    return "La venta debe tener al menos un detalle.";

                var cliente = repositorio.BuscarClientePorId(venta.ClienteId);

                if (cliente == null)
                    return "Cliente inválido.";

                decimal totalBruto = venta.Detalles.Sum(d => d.Subtotal);
                decimal descuento = 0;

                // 🔹 Descuento por tipo de cliente
                if (cliente.Tipo == "Mayorista")
                    descuento += 0.25m;

                // 🔹 Descuento por método de pago
                if (venta.MetodoPago == "Transferencia")
                    descuento += 0.10m;
                else if (venta.MetodoPago == "Efectivo")
                    descuento += 0.20m;
                // Tarjeta no tiene descuento

                decimal totalFinal = totalBruto - (totalBruto * descuento);

                venta.Total = totalFinal;

                repositorio.RegistrarVenta(venta);

                return $"Venta registrada correctamente.\nTotal bruto: ${totalBruto}\nDescuento: {descuento * 100}%\nTotal final: ${totalFinal}";
            }
            catch (Exception ex)
            {
                return "Error al registrar venta: " + ex.Message;
            }
        }

        public string GenerarFactura(Venta venta)
        {
            var cliente = repositorio.BuscarClientePorId(venta.ClienteId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------ FACTURA ------");
            sb.AppendLine($"Fecha: {venta.Fecha}");
            sb.AppendLine($"Cliente: {cliente.Nombre}");
            sb.AppendLine($"Tipo: {cliente.Tipo}");
            sb.AppendLine($"Metodo de pago: {venta.MetodoPago}");
            sb.AppendLine("----------------------");

            foreach (var d in venta.Detalles)
            {
                sb.AppendLine($"{d.Producto.Nombre} x{d.Cantidad} - ${d.Subtotal}");
            }

            sb.AppendLine("----------------------");
            sb.AppendLine($"TOTAL: ${venta.Total}");

            return sb.ToString();
        }


        // ---------- REPORTES ----------
        public List<object> ReporteVentasPorPeriodo(DateTime desde, DateTime hasta)
    => repositorio.ReporteVentasPorPeriodo(desde, hasta);

        public List<object> ReporteVentasPorProducto()
            => repositorio.ReporteVentasPorProducto();

        public List<object> ReporteVentasPorSucursal()
            => repositorio.ReporteVentasPorSucursal();

        public List<object> EstadoCuentaClientes()
            => repositorio.EstadoCuentaClientes();
    }
}
