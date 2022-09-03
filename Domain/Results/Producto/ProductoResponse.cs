using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Results.Producto
{
    [DataContract]
    public class ProductoResponse
    {
        [DataMember(Name = "idarticulo")]
        public int idarticulo { get; set; }

        [DataMember(Name = "idcategoria")]
        public int idcategoria { get; set; }

        [DataMember(Name = "codigo")]
        public string codigo { get; set; }

        [DataMember(Name = "nombreArticulo")]
        public string nombreArticulo { get; set; }

        [DataMember(Name = "precio_venta")]
        public decimal precio_venta { get; set; }

        [DataMember(Name = "stock")]
        public int stock { get; set; }

        [DataMember(Name = "descripcionArticulo")]
        public string descripcionArticulo { get; set; }

        [DataMember(Name = "nombreCategoria")]
        public string nombreCategoria { get; set; }

        [DataMember(Name = "descripcionCategoria")]
        public string descripcionCategoria { get; set; }

    }
}
