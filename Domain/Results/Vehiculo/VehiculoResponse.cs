using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Results.Vehiculo
{
  public  class VehiculoResponse
    {
        public int   idVehiculo { get; set; }       
        public string   modelo { get; set; }
        public string placa { get; set; }
        public string serie { get; set; }
    }
}
