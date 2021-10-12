using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Results.Users
{
    [DataContract]
  public  class UserMeResult
    {
        [DataMember(Name = "id_rol")]
        public int IdRol { get; set; }

        [DataMember(Name = "nombre")]
        public string nombre { get; set; }

        [DataMember(Name = "tipo_documento")]
        public string TipoDocumento { get; set; }

        [DataMember(Name = "numero_documento")]
        public string NumeroDocumento { get; set; }

        [DataMember(Name = "direccion")]
        public string Direccion { get; set; }

        [DataMember(Name = "telefono")]
        public string Telefono { get; set; }

        [DataMember(Name = "estado")]
        public bool Estado { get; set; }

        [DataMember(Name = "tipo_rol")]
        public string tipo_rol { get; set; }

        [DataMember(Name = "descripcion_rol")]
        public string descripcion_rol { get; set; }

        [DataMember(Name = "email")]
        public string email { get; set; }

        public UserMeResult(int IdRol_, string nombre_, string TipoDocumento_, string NumeroDocumento_, string Direccion_, string Telefono_, bool Estado_, string tipo_rol_ , string descripcion_rol_ ,string email_)
        {
            IdRol = IdRol_;
            nombre = nombre_;
            TipoDocumento = TipoDocumento_;
            NumeroDocumento = NumeroDocumento_;
            Direccion = Direccion_;
            Telefono = Telefono_;
            Estado = Estado_;
            tipo_rol = tipo_rol_;
            descripcion_rol = descripcion_rol_;
            email = email_;

        }
    }
}
