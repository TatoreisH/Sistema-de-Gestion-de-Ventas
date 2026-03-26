using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }

        public ICollection<VentaDetalle> Detalles { get; set; }
    }
}
