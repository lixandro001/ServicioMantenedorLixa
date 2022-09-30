using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Conductor;
using Domain.Payloads.Vehiculo;
using Domain.Results.Conductor;
using Domain.Results.Ruta;
using Domain.Results.Vehiculo;
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

        Task<(ServiceStatus, string)> AgregarAsignacionHorariosDias(NuevaAsignaciomHorariosDias request);
         
        Task<(ServiceStatus, string, Pagination<ConductorResponse>)> GetListConductor(string query, string user, int? page = 1);
        Task<(ServiceStatus, string, Pagination<VehiculoResponse>)> GetListVehiculo(string query, string user, int? page = 1);
        Task<(ServiceStatus,string)> AsignacionVehiculos(AsignacionVehiculos request);
        Task<(ServiceStatus, string, List<RutaResponse>)> GetListRutaCombo();
    }
}
