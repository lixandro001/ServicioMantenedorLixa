
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Conductor;
using Domain.Payloads.Vehiculo;
using Domain.Results;
using Domain.Results.Conductor;
using Domain.Results.Ruta;
using Domain.Results.Vehiculo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ConductorService :IConductorService
    {
        private readonly IConductorRepository conductorRepository;
    
        public ConductorService(IConductorRepository conductorRepository)
        {
            this.conductorRepository = conductorRepository;
        }

        public async Task<MessageResult> AgregarConductor(NuevoConductor request)
        {
            var (status, message) = await conductorRepository.AgregarConductor(request);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return MessageResult.Of(message);
        }

        public async Task<MessageResult> AgregarVehiculo(NuevoVehiculo request)
        {
            var (status, message) = await conductorRepository.AgregarVehiculo(request);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return MessageResult.Of(message);
        }

        public async Task<MessageResult> AgregarAsignacionHorariosDias(NuevaAsignaciomHorariosDias request)
        {
            var (status, message) = await conductorRepository.AgregarAsignacionHorariosDias(request);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return MessageResult.Of(message);
        }

       

        public async Task<MessageResult> AsignacionVehiculos(AsignacionVehiculos request)
        {
            var (status, message) = await conductorRepository.AsignacionVehiculos(request);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return MessageResult.Of(message);
        }


        public async Task<Pagination<ConductorResponse>> GetListConductor(string query, string user, int? page)
        {
            var (status, message, result) = await conductorRepository.GetListConductor(query, user, page);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return result;
        }


        public async Task<Pagination<VehiculoResponse>> GetListVehiculo(string query, string user, int? page)
        {
            var (status, message, result) = await conductorRepository.GetListVehiculo(query, user, page);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return result;
        }


        public async Task<List<RutaResponse>> GetListRutaCombo()
        {
            var (status, message, result) = await conductorRepository.GetListRutaCombo( );

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return result;
        }


        


    }
}
