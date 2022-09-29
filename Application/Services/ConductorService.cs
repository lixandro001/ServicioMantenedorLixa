
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Conductor;
using Domain.Payloads.Vehiculo;
using Domain.Results;
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

         

    }
}
