using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace Domain.Payloads.Client
{
    [DataContract]
   public class ClientPdfPayload
    {
        [DataMember(Name = "ticket")]
        public string Ticket { get; set; }

        [DataMember(Name = "logo")]
        public string Logo { get; set; }

        [DataMember(Name = "firm")]
        public string Firma { get; set; }

        [DataMember(Name = "report_type")]
        public string ReportType { get; set; }
    }
}
