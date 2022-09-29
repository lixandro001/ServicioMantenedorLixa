﻿using Domain.Enumerations;
using Domain.Payloads.Conductor;
using Domain.Payloads.Vehiculo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IConductorRepository
    {
        Task<(ServiceStatus, string)> AgregarConductor(NuevoConductor request);
        Task<(ServiceStatus, string)> AgregarVehiculo(NuevoVehiculo request);
         

    }
}
