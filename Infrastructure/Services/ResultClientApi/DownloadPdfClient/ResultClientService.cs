using Application.Interfaces.IOthers.ResultClient;
using Domain.Enumerations;
using Domain.Payloads.Client.ClientService;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.ResultClientApi.DownloadPdfClient
{
  public class ResultClientService : IResultClientService
    {
        private readonly ResultClient resultPatientClient;

        public ResultClientService(ResultClient resultPatientClient)
        {
            this.resultPatientClient = resultPatientClient;
        }

        public async Task<(ServiceStatus, string, T)> GetPdfResult<T>(ClientPdfServicePayload payload)
        {
            return await resultPatientClient.ExecuteClientRequest<T>(HttpMethod.Post, ResultsClientEndpoints.PatientApi.GetPdfResult(), payload);
        }

    }
}
