using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Repositorio
    {
        private readonly Context context;

        public Repositorio()
        {
            context = new Context();
        }

        // CLIENTES


        public IReadOnlyCollection<Cliente> ListarClientes()
            => context.Clientes.ToList().AsReadOnly();

        public void AgregarCliente(Cliente c)
        {
            context.Clientes.Add(c);
            context.SaveChanges();
        }

        public void ModificarCliente(Cliente c)
        {
            context.Clientes.Update(c);
            context.SaveChanges();
        }

        public void EliminarCliente(Cliente c)
        {
            context.Clientes.Remove(c);
            context.SaveChanges();
        }

        // PRODUCTOS

        public IReadOnlyCollection<Producto> ListarProductos()
            => context.Productos.ToList().AsReadOnly();

        public Producto ObtenerProducto(int codigo)
            => context.Productos.FirstOrDefault(p => p.Codigo == codigo);

        public Producto? BuscarProductoCodigo(int codigo)
            => context.Productos.FirstOrDefault(p => p.Codigo == codigo);

        public Producto? BuscarProductoNombre(string nombre)
            => context.Productos.FirstOrDefault(p => p.Nombre == nombre);

        public void AgregarProducto(Producto p)
        {
            context.Productos.Add(p);
            context.SaveChanges();
        }

        public void ModificarProducto(Producto p)
        {
            context.Productos.Update(p);
            context.SaveChanges();
        }

        public string EliminarProducto(Producto producto)
        {
            // Primero eliminar registros de stock relacionados
            var stocks = context.ProductosSucursales
                                .Where(ps => ps.CodigoProducto == producto.Codigo)
                                .ToList();

            context.ProductosSucursales.RemoveRange(stocks);
            context.SaveChanges();

            // Ahora sí se puede eliminar el producto
            context.Productos.Remove(producto);
            context.SaveChanges();

            return "Producto eliminado correctamente junto con su stock.";
        }


        // CATEGORIAS

        public IReadOnlyCollection<Categoria> ListarCategorias()
            => context.Categorias.ToList().AsReadOnly();

        public Categoria? BuscarCategoriaPorNombre(string nombre)=> context.Categorias.FirstOrDefault(c => c.Nombre == nombre);

        public void AgregarCategoria(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
        }

        // SUCURSALES   

        public IReadOnlyCollection<Sucursal> ListarSucursales()
            => context.Sucursales.ToList().AsReadOnly();

        public void AgregarSucursal(Sucursal s)
        {
            context.Sucursales.Add(s);
            context.SaveChanges();
        }

        public Sucursal? BuscarSucursalPorNombre(string nombre)
        {
            return context.Sucursales
                .FirstOrDefault(x => x.Nombre == nombre);
        }

        public void EliminarSucursal(Sucursal s)
        {
            context.Sucursales.Remove(s);
            context.SaveChanges();
        }

        // PRODUCTO - SUCURSAL (STOCK)
        
        public IReadOnlyCollection<ProductoSucursal> ListarProductosPorSucursal(int sucursalId)
        {
            return context.ProductosSucursales
                .Where(ps => ps.SucursalId == sucursalId)
                .Include(ps => ps.Producto)
                .Include(ps => ps.Sucursal)
                .ToList()
                .AsReadOnly();
        }

        public void AgregarOActualizarProductoSucursal(ProductoSucursal ps)
        {
            var existente = context.ProductosSucursales
                .FirstOrDefault(x => x.CodigoProducto == ps.CodigoProducto &&
                                     x.SucursalId == ps.SucursalId);

            if (existente == null)
            {
                context.ProductosSucursales.Add(ps);
            }
            else
            {
                existente.Stock = ps.Stock;   
                context.ProductosSucursales.Update(existente);
            }

            context.SaveChanges();
        }

        public Producto BuscarProductoPorCodigo(int codigo)
        {
            return ObtenerProducto(codigo);         
        }

        // VENTAS

        public void RegistrarVenta(Venta venta)
        {
            context.Ventas.Add(venta);

            foreach (var d in venta.Detalles)
            {
                DescontarStock(d.CodigoProducto, venta.SucursalId, d.Cantidad);
            }

            context.SaveChanges();
        }

        public void DescontarStock(int codigoProducto, int sucursalId, int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad a descontar debe ser mayor a 0.", nameof(cantidad));

            var ps = context.ProductosSucursales
                .FirstOrDefault(x => x.CodigoProducto == codigoProducto && x.SucursalId == sucursalId);

            if (ps == null)
                throw new InvalidOperationException($"No existe registro de stock para el producto {codigoProducto} en la sucursal {sucursalId}.");

            if (ps.Stock < cantidad)
                throw new InvalidOperationException($"Stock insuficiente del producto {codigoProducto} en la sucursal {sucursalId}. Disponible: {ps.Stock}, pedido: {cantidad}.");

            ps.Stock -= cantidad;
            context.ProductosSucursales.Update(ps);
        }

        public Cliente BuscarClientePorId(int id)
        {
            return context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public IReadOnlyCollection<Venta> ListarVentas()
        {
            return context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Detalles)
                .ThenInclude(d => d.Producto)
                .ToList()
                .AsReadOnly();
        }

        // REPORTES (CON DTO)

        public List<object> ReporteVentasPorPeriodo(DateTime desde, DateTime hasta)
        {
            return context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Sucursal)
                .Where(v => v.Fecha.Date >= desde.Date && v.Fecha.Date <= hasta.Date)
                .Select(v => new
                {
                    v.Id,
                    v.Fecha,
                    Cliente = v.Cliente.Nombre,
                    Sucursal = v.Sucursal.Nombre,
                    v.Total
                })
                .ToList<object>();
        }

        public List<object> ReporteVentasPorProducto()
        {
            return context.VentaDetalles
                .Where(d => d.Producto != null)
                .GroupBy(d => d.Producto.Nombre)
                .Select(g => new
                {
                    Producto = g.Key,
                    Cantidad = g.Sum(x => x.Cantidad)
                })
                .OrderByDescending(x => x.Cantidad)
                .ToList<object>();
        }


        public List<object> ReporteVentasPorSucursal()
        {
            return context.Ventas
                .Include(v => v.Sucursal)
                .GroupBy(v => v.Sucursal.Nombre)
                .Select(g => new
                {
                    Sucursal = g.Key,
                    TotalVendido = g.Sum(x => x.Total)
                })
                .ToList<object>();
        }

        public List<object> EstadoCuentaClientes()
        {
            return context.Clientes
                .Include(c => c.Ventas)   // ✅ IMPORTANTE
                .Select(c => new
                {
                    c.Nombre,
                    TotalComprado = c.Ventas.Sum(v => v.Total)
                })
                .ToList<object>();
        }
    }
}