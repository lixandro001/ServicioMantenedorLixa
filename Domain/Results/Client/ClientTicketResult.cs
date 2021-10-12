using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Domain.Results.Client
{
    [DataContract]
    public class ClientTicketResult
    {
        [DataMember(Name = "ticket")]
        public string Ticket { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "cia")]
        public string CIA { get; set; }

        [DataMember(Name = "company")]
        public string Company { get; set; }

        [DataMember(Name = "ncopac")]
        public string Ncopac { get; set; }

        [DataMember(Name = "sex")]
        public string Sex { get; set; }

        [DataMember(Name = "age")]
        public string Age { get; set; }

        [DataMember(Name = "total_sale")]
        public string TotalSale { get; set; }

        [DataMember(Name = "total_sol")]
        public string TotalSol { get; set; }

        [DataMember(Name = "total_must")]
        public string TotalMust { get; set; }

        [DataMember(Name = "number_type_Ssale")]
        public string NumberTypeSale { get; set; }

        [DataMember(Name = "serie")]
        public string Serie { get; set; }

        [DataMember(Name = "number")]
        public string Number { get; set; }

        [DataMember(Name = "document")]
        public string Document { get; set; }

        [DataMember(Name = "user_web")]
        public string UserWeb { get; set; }

        [DataMember(Name = "passwrod_web")]
        public string PasswordWeb { get; set; }

        [DataMember(Name = "web_access")]
        public string WebAccess { get; set; }

        [DataMember(Name = "percentage")]
        public string Percentage { get; set; }

        [DataMember(Name = "numoscab")]
        public string Numoscab { get; set; }

        [DataMember(Name = "peroscab")]
        public string Peroscab { get; set; }

        [DataMember(Name = "anooscab")]
        public string Anooscab { get; set; }

        [DataMember(Name = "numsuc")]
        public string Numuc { get; set; }

        [DataMember(Name = "numemp")]
        public string Numemp { get; set; }


    }
}
