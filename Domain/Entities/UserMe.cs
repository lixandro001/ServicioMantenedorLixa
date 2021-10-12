using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class UserMe
    {
  
        public int IdRol { get; set; }
        public string nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public string tipo_rol { get;set; }
        public string descripcion_rol { get; set; }
        public string email { get; set; }

    }
}
