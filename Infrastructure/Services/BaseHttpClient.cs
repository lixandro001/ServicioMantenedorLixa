using Domain.Entities;
using Domain.Enumerations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
   public class BaseHttpClient
    {
        private readonly HttpClient _httpClient;

        protected BaseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<(ServiceStatus, string, T)> ExecuteRequest<T>(HttpMethod httpMethod, string uri, object content = null, Token token = null)
        {
            try
            {

                var request = CreateRequest(httpMethod, uri, content, token);

                var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                                                .ConfigureAwait(false);

                if (response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.InternalServerError &&
                    response.StatusCode != HttpStatusCode.BadRequest && response.StatusCode != HttpStatusCode.Unauthorized && response.StatusCode != HttpStatusCode.Forbidden)
                {
                    return (ServiceStatus.InternalError, "Error no identificado", default);
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return (ServiceStatus.Unauthorized, "Antes debe loguearse", default);
                }

                if (response.StatusCode == HttpStatusCode.BadRequest ||
                    response.StatusCode == HttpStatusCode.InternalServerError ||
                    response.StatusCode == HttpStatusCode.Forbidden)
                {
                    var message = await Task.Run(async () => JsonConvert.DeserializeObject<Status>(await response.Content.ReadAsStringAsync()));

                    message.Message = message.Message.Replace('-', ' ');
                    message.Message = message.Code != null ? $"{ message.Message } - { message.Code }" : $"{ message.Message } - no code";

                    return ((ServiceStatus)response.StatusCode, message.Message, default);
                }

                return await Task.Run(async () => (ServiceStatus.Ok, "success", JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())));

            }
            catch (Exception e)
            {
                return (ServiceStatus.InternalError, e.Message, default);
            }
        }

        private HttpRequestMessage CreateRequest(HttpMethod httpMethod, string uri, object content = null, Token token = null)
        {
            var request = new HttpRequestMessage(httpMethod, uri);

            if (token != null) request.Headers.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

            if (content != null)
            {
                if (content is MultipartFormDataContent)
                    request.Content = content as MultipartFormDataContent;
                else
                    request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }

            return request;
        }



    }
}
