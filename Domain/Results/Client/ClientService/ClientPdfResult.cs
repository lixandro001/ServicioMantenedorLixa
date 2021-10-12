using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Results.Client.ClientService
{
   public class ClientPdfResult
    {
        public ClientPdfResult()
        {
            UrlPdf = new List<string>();
        }

        [JsonProperty("pdf")]
        public byte[] Pdf { get; set; }

        [JsonProperty("result")]
        public List<string> UrlPdf { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
