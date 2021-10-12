using AutoMapper;
using Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Payloads.Client.ClientService
{
   public class ClientPdfServicePayload : IMapFrom<ClientPdfPayload>
    {

        [JsonProperty("Ticket")]
        public string Ticket { get; set; }

        [JsonProperty("Logo")]
        public string Logo { get; set; }

        [JsonProperty("firma")]
        public string Firma { get; set; }

        [JsonProperty("TipoInforme")]
        public string ReportType { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ClientPdfPayload, ClientPdfServicePayload>()
                .ForMember(c => c.Firma, opt => opt.MapFrom(src => src.Firma))
                .ForMember(c => c.Logo, opt => opt.MapFrom(src => src.Logo))
                .ForMember(c => c.ReportType, opt => opt.MapFrom(src => src.ReportType))
                .ForMember(c => c.Ticket, opt => opt.MapFrom(src => src.Ticket));

        }

    }
}
