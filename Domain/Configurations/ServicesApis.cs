using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Configurations
{
    [DataContract]
    public sealed  class ServicesApis
    {
        [DataMember(Name = "ApiPdfResult")]
        public string ApiPdfResult { get; set; }
    }
}
