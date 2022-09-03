using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Payloads.Producto
{
    public class NewProducto
    {
        public int idcategoria { get; set; }
        public string nombre { get; set; }
        public decimal precio_venta { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }

    }
}
