using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Results.Client
{
    [DataContract]
    public class ClientUrlPdfResult
    {
        [DataMember(Name = "url_pdf")]
        public string UrlPdf { get; set; }

    }
}
