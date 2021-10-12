using Application.Helpers;
using Domain.Payloads.Auths;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validates.Auths
{
     
    public class AuthPayloadValidation : AbstractValidator<AuthPayload>
    {
        public AuthPayloadValidation()
        {
            RuleFor(c => c.Password).NotEmpty().WithMessage(MessagesHelper.NotEmpty("Password")); //no puede ser vacio
            RuleFor(c => c.Username).NotEmpty().WithMessage(MessagesHelper.NotEmpty("Username"));  //no puede ser vacio
        }
    }
}
