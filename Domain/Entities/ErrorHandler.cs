using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Entities
{
   public class ErrorHandler : Exception
    {
        [IgnoreDataMember]
        public HttpStatusCode Code { get; }

        [DataMember(Name = "message")]
        public string Message { get; }

        public ErrorHandler(HttpStatusCode code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
