using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Payloads.Vehiculo
{
    public class AsignacionVehiculos
    {
        public int idvehiculo { get; set; }
        public int idconductor { get; set; }
        public bool duenoVehiculo { get; set; }
    }
}
