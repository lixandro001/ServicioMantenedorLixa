using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Payloads.Vehiculo
{
   public class NuevoVehiculo
    {
      public string usuario { get; set; } 
      public string modelo { get; set; }
      public string placa { get; set; }
      public DateTime  fechaCompra { get; set; }
      public string serie { get; set; }
    }
}
