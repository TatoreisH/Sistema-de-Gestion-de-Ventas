using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Modelo
{
    public class Context : DbContext
    {
        private string conexion = @"Data Source=LACHADD\SQLEXPRESS;
              Initial Catalog=TechStoreDB;
              Integrated Security=True;
              Persist Security Info=False;
              Pooling=False;
              Encrypt=False;";

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<ProductoSucursal> ProductosSucursales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(conexion);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key para ProductoSucursal
            modelBuilder.Entity<ProductoSucursal>()
                .HasKey(ps => new { ps.CodigoProducto, ps.SucursalId });

            modelBuilder.Entity<ProductoSucursal>()
                .HasOne(ps => ps.Producto)
                .WithMany(p => p.ProductosSucursales)
                .HasForeignKey(ps => ps.CodigoProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductoSucursal>()
                .HasOne(ps => ps.Sucursal)
                .WithMany(s => s.ProductosSucursales)
                .HasForeignKey(ps => ps.SucursalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relaciones Venta - VentaDetalle
            modelBuilder.Entity<VentaDetalle>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VentaDetalle>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.CodigoProducto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
