using Application.Helpers;
using Domain.Configurations;
using Domain.Entities;
using Domain.Enumerations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Services.ResultClientApi
{
   public class ResultClient : BaseHttpClient
    {
        public ResultClient(HttpClient httpClient, IConfiguration configuration, IOptions<BasicAuthentication> basicAuthentication) : base(httpClient)
        {
            httpClient.DefaultRequestHeaders.Clear();
            //httpClient.DefaultRequestHeaders.Add(
            //    "Authorization",
            //    SecurityHelper.GetCredentialsBasicAuthentication(basicAuthentication.Value.User, basicAuthentication.Value.Password)
            //);
        }

        public async Task<(ServiceStatus, string, T)> ExecuteClientRequest<T>(HttpMethod httpMethod, string uri, object content = null, Token token = null)
        {
            return await ExecuteRequest<T>(httpMethod, uri, content, token);
        }

    }
}
