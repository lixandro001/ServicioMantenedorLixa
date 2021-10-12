using Domain.Entities;
using Domain.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using serviciosMantenimiento.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace serviciosMantenimiento.Middlewares.ErrorMiddlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        //public async Task InvokeAsync(HttpContext context, IUserManagementService service)
        //{
        //    if (!context.User.Identity.IsAuthenticated)
        //    {
        //        // We skip to the next middleware if the endpoint has been flagged as not authenticated,
        //        // usually happens if the endpoint has the decorator AllowAnonymous.
        //        await next.Invoke(context);

        //        return;
        //    }

        //    var _user = context.User.GetUser();

        //    var isActive = await service.IsUserActiveAsync(_user.Estado);

        //    if (!isActive)
        //    {
        //        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        //        context.Response.ContentType = "application/json";
        //        await context.Response.WriteAsync(JsonConvert.SerializeObject(MessageResult.Of(
        //            "Acceso de usuario ha sido desactivado")));

        //        return;
        //    }

        //    await next.Invoke(context);
        //}

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ErrorHandlerAsync(context, ex);
            }
        }

        private async Task ErrorHandlerAsync(HttpContext context, Exception ex)
        {
            string message = null;

            context.Response.ContentType = "application/json";

            switch (ex)
            {
                case ErrorHandler eh:

                    context.Response.StatusCode = (int)eh.Code;
                    message = eh.Message;

                    break;

                case Exception e:

                    message = string.IsNullOrWhiteSpace(e.Message) ? "Error desconocido" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    break;
            }

            if (message != null)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(MessageResult.Of(message)));
            }
        }

    }
}
