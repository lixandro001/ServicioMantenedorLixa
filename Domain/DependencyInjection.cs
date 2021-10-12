using Domain.Configurations;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Domain
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration Configuration)
        {
            // Register token settings, basic authenticate and services api
            services.Configure<TokenManagement>(Configuration.GetSection("TokenManagement"))
                    .Configure<ServicesApis>(Configuration.GetSection("ServicesApis"))
                    .Configure<BasicAuthentication>(Configuration.GetSection("BasicAuthentication"));

            #region AutoMapper

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion

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
