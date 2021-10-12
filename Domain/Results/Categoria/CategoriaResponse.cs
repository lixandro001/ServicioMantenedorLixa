using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Results.Categoria
{
    [DataContract]
    public class CategoriaResponse
    {
        [DataMember(Name = "idcategoria")]
        public int idcategoria { get; set; }


        [DataMember(Name = "nombreCategoria")]
         public string nombreCategoria { get; set; }


        [DataMember(Name = "descripcion")]
        public string descripcion { get; set; }


        [DataMember(Name = "estado")]
        public bool estado { get; set; }


        [DataMember(Name = "nombreEstado")]
        public string nombreEstado { get; set; }

    }
}
