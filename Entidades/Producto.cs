using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Producto
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public ICollection<ProductoSucursal> ProductosSucursales { get; set; }
        public ICollection<VentaDetalle> VentaDetalles { get; set; }
    }
}

