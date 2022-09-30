using Domain.Entities;
using Domain.Payloads.Conductor;
using Domain.Payloads.Vehiculo;
using Domain.Results;
using Domain.Results.Categoria;
using Domain.Results.Conductor;
using Domain.Results.Ruta;
using Domain.Results.Vehiculo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
   public interface IConductorService
    {
        Task<MessageResult> AgregarConductor(NuevoConductor request);
        Task<MessageResult> AgregarVehiculo(NuevoVehiculo request);
        Task<MessageResult> AgregarAsignacionHorariosDias(NuevaAsignaciomHorariosDias request);

      
        Task<Pagination<ConductorResponse>> GetListConductor(string query, string user, int? page);
        Task<Pagination<VehiculoResponse>> GetListVehiculo(string query, string user, int? page);
        Task<MessageResult> AsignacionVehiculos(AsignacionVehiculos request);
        Task<List<RutaResponse>> GetListRutaCombo();

    }
}
