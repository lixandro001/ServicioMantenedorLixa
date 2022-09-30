using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Results.Conductor
{
   public class ConductorResponse
    {
          public string   Dni { get; set; }
          public string Apellido { get; set; }
          public string NombreCompleto { get; set; }
          public int  idConductor { get; set; }
          public string NumeroLicencia { get; set; }
    }
}
