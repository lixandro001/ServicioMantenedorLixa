using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Auths;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IAuthenticationRepository
    {
        Task<(ServiceStatus, string, UserMe)> Auth(AuthPayload payload);
    }
}



