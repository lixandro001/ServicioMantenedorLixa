using Application.Interfaces;
using Application.Interfaces.IOthers.ResultClient;
using Application.Interfaces.IRepositories;
using Domain.Configurations;
using Infrastructure.Report.Templates;
using Infrastructure.Repositories;
using Infrastructure.Securities;

using Infrastructure.Services.ResultClientApi;
using Infrastructure.Services.ResultClientApi.DownloadPdfClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            var servicesApis = Configuration.GetSection("ServicesApis").Get<ServicesApis>();

            #region JWT

            services.AddScoped<IJwtGenerator, JwtGenerator>();

            #endregion


            #region reporte excel

            services.AddScoped<IReportes, ReporteDatosCategoria>();

            #endregion



            #region Services para consumir otro backend

            services.AddHttpClient<ResultClient>("SapClient", config =>
            {
                config.BaseAddress = new Uri(servicesApis.ApiPdfResult);
                config.Timeout = TimeSpan.FromSeconds(60);
            });

            services.AddScoped<IResultClientService, ResultClientService>();

            //services.AddHttpClient<ElectronicBillingClient>("ElectronicBillingClient", config =>
            //{
            //    config.BaseAddress = new Uri(servicesApis.FEServiceApi);
            //    config.Timeout = TimeSpan.FromSeconds(60);
            //});

            //services.AddScoped<IElectronicBillingService, ElectronicBillingService>();
            #endregion

            #region Repositories

            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>()
                    //.AddScoped<IClientRepository, ClientRepository>()
                    .AddScoped<ICategoriaRepository, CategoriaRepository>()
                    .AddScoped<IProductoRepository, ProductosRepository>()
                    .AddScoped<IConductorRepository, ConductorRepository>()
                    ;

            #endregion

            return services;
        }

        
    }
}
