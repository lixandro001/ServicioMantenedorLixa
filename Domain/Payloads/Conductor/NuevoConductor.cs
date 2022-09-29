using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Payloads.Conductor
{
   public class NuevoConductor
    {
        public int IdSexo { get; set; }
        public string idusuario { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNcimiento { get; set; }
        public string Direccion { get; set; }
        public string NumeroLicencia { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool LicenciaValidada { get; set; }
        public string mensaje { get; set; }
        public int valor { get; set; }
    }
}
