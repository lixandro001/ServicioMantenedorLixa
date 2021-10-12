using Domain.Enumerations;
using Domain.Payloads.Client.ClientService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IOthers.ResultClient
{
    public interface IResultClientService
    {
        Task<(ServiceStatus, string, T)> GetPdfResult<T>(ClientPdfServicePayload payload);
    }

}
