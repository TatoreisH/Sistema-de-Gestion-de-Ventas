using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; } 
        public string Email { get; set; }
        public long Telefono { get; set; } 

        public ICollection<Venta> Ventas { get; set; }
    }
}
