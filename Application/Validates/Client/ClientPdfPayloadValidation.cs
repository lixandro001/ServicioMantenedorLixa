using Application.Helpers;
using Domain.Payloads.Client;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validates.Client
{
  public  class ClientPdfPayloadValidation : AbstractValidator<ClientPdfPayload>
    {
        public ClientPdfPayloadValidation()
        {
            RuleFor(c => c.Firma).NotEmpty().WithMessage(MessagesHelper.NotEmpty("Firma"));
            RuleFor(c => c.Logo).NotEmpty().WithMessage(MessagesHelper.NotEmpty("Logo"));
            RuleFor(c => c.ReportType).NotEmpty().WithMessage(MessagesHelper.NotEmpty("ReportType"));
            RuleFor(c => c.Ticket).NotEmpty().WithMessage(MessagesHelper.NotEmpty("Ticket"));
        }
    }
}
