using Domain.Payloads.Auths;
using Domain.Payloads.Client;
using Domain.Results.Client;
using Domain.Results.Client.ClientService;
using Domain.Results.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IClientService
    {
        //Task<UserMeResult> GetInfoPaient(AuthPayload payload);
        //Task<object> GetInfoPaientTikets(AuthPayload payload, int? page = 1);
        //Task<object> GetInfoPaientTiketsDetail(string numoscab, string peroscab, string anooscab, string numsuc, string numemp, int? page = 1);
        Task<ClientPdfResult> DownloadPdfResult(ClientPdfPayload payload);
        Task<ClientUrlPdfResult> GetUrlPdfResult(ClientPdfPayload payload);

    }
}
