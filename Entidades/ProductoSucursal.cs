using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoSucursal
    {
        public int CodigoProducto{ get; set; }
        public Producto Producto { get; set; }

        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }

        public int Stock { get; set; }
    }
}
