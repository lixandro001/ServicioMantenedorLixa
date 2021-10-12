using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Results.Client
{
    [DataContract]
   public class ClientTicketDetailResult
    {
        [DataMember(Name = "nro")]
        public string Nro { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "service")]
        public string Service { get; set; }

        [DataMember(Name = "scanned")]
        public string Scanned { get; set; }

        [DataMember(Name = "validated")]
        public string Validated { get; set; }

        [DataMember(Name = "date_scanned")]
        public string DateScanned { get; set; }

        [DataMember(Name = "date_validated")]
        public string DateValidated { get; set; }

        [DataMember(Name = "laboratory_order")]
        public string LaboratoryOrder { get; set; }

    }
}
