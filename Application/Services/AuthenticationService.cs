using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Auths;
using Domain.Results.Auths;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    class AuthenticationService: IAuthenticationService
    {

        private readonly IAuthenticationRepository authenticationRepository;

        private readonly IJwtGenerator jwtGenerator;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IJwtGenerator jwtGenerator)
        {
            this.authenticationRepository = authenticationRepository;
            this.jwtGenerator = jwtGenerator;
        }

        public async Task<AuthResult> Auth(AuthPayload payload)
        {
            var (status, message, user) = await authenticationRepository.Auth(payload);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );
             

            return await jwtGenerator.CreateToken(user);
        }

    }
}
