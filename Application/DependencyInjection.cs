﻿using Application.Interfaces.IServices;
using Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IAuthenticationService, AuthenticationService>()
                    .AddScoped<IClientService, ClientService>()
                    .AddScoped<ICategoriaService, CategoriaService>();
            



            // FluentValidation
            services.AddControllers()
                .AddFluentValidation(opt => {
                    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                }
            );

            return services;
        }
    }
}
