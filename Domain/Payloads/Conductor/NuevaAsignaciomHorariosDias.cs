using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Payloads.Conductor
{
    public class NuevaAsignaciomHorariosDias
    {
        public string IdUsuario { get; set; }
        public int IdConductor { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public bool domingo { get; set; }
    }
}
