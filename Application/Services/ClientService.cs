using Application.Interfaces.IOthers.ResultClient;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Auths;
using Domain.Payloads.Client;
using Domain.Payloads.Client.ClientService;
using Domain.Results.Client;
using Domain.Results.Client.ClientService;
using Domain.Results.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    class ClientService: IClientService
    {

        private readonly IClientRepository patientRepository;

        private readonly IResultClientService resultPatientService;

        private readonly IMapper mapper;

        public ClientService(IClientRepository patientRepository,
            IResultClientService resultPatientService,
            IMapper mapper)
        {
            this.patientRepository = patientRepository;
            this.resultPatientService = resultPatientService;
            this.mapper = mapper;
        }

        //public async Task<UserMeResult> GetInfoPaient(AuthPayload payload)
        //{
        //    var (status, message, response) = await patientRepository.GetInfoPaient(payload);

        //    if (status != ServiceStatus.Ok)
        //        throw new ErrorHandler(
        //                status == ServiceStatus.FailedValidation
        //                ? HttpStatusCode.BadRequest
        //                : HttpStatusCode.InternalServerError
        //            , message
        //            );

        //    return response;
        //}

        //public async Task<object> GetInfoPaientTikets(AuthPayload payload, int? page = 1)
        //{
        //    if (page.HasValue && page < 1)
        //    {
        //        throw new ErrorHandler(HttpStatusCode.BadRequest, "Pagina no puede ser cero o negativo");
        //    }

        //    var (status, message, total, response) = await patientRepository.GetInfoPaientTikets(payload, page);

        //    if (status != ServiceStatus.Ok)
        //        throw new ErrorHandler(
        //                status == ServiceStatus.FailedValidation
        //                ? HttpStatusCode.BadRequest
        //                : HttpStatusCode.InternalServerError
        //            , message
        //            );

        //    return new
        //    {
        //        total = total,
        //        entries = response
        //    };
        //}

        //public async Task<object> GetInfoPaientTiketsDetail(string numoscab, string peroscab, string anooscab, string numsuc, string numemp, int? page = 1)
        //{
        //    if (page.HasValue && page < 1)
        //    {
        //        throw new ErrorHandler(HttpStatusCode.BadRequest, "Pagina no puede ser cero o negativo");
        //    }

        //    var (status, message, total, response) = await patientRepository.GetInfoPaientTiketsDetail(numoscab, peroscab, anooscab, numsuc, numemp, page);

        //    if (status != ServiceStatus.Ok)
        //        throw new ErrorHandler(
        //                status == ServiceStatus.FailedValidation
        //                ? HttpStatusCode.BadRequest
        //                : HttpStatusCode.InternalServerError
        //            , message
        //            );

        //    return new
        //    {
        //        total = total,
        //        entries = response
        //    };
        //}

        public async Task<ClientPdfResult> DownloadPdfResult(ClientPdfPayload payload)
        {
            var (status, message, response) = await resultPatientService.GetPdfResult<ClientPdfResult>(mapper.Map<ClientPdfServicePayload>(payload));

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            if (response.Pdf == null)
            {
                throw new ErrorHandler(HttpStatusCode.BadRequest, "Estamos teniendo inconvenientes con nuestro servicio de resultados");
            }

            return response;
        }


        public async Task<ClientUrlPdfResult> GetUrlPdfResult(ClientPdfPayload payload)
        {
            var (status, message, response) = await resultPatientService.GetPdfResult<ClientPdfResult>(mapper.Map<ClientPdfServicePayload>(payload));

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            if (response.Pdf == null)
            {
                throw new ErrorHandler(HttpStatusCode.BadRequest, "Estamos teniendo inconvenientes con nuestro servicio de resultados");
            }

            if (response.UrlPdf.Count == 0)
            {
                throw new ErrorHandler(HttpStatusCode.BadRequest, "Lo sentimos, no se encontró la ruta");
            }

            return new ClientUrlPdfResult { UrlPdf = response.UrlPdf[0] };
        }

    }
}
