using Domain.Payloads.Auths;
using Domain.Results.Auths;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
   public interface IAuthenticationService
    {
        Task<AuthResult> Auth(AuthPayload payload);
    }
}
