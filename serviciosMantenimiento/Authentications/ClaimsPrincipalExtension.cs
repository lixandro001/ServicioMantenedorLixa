using Domain.Entities;
using Domain.Results.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Infrastructure.Securities.JwtGenerator;

namespace serviciosMantenimiento.Authentications
{
    public static class ClaimsPrincipalExtension
    {
        public static UserMeResult GetUser(this ClaimsPrincipal principal)
        {
            var IdRol = principal.FindFirstValue(JWTClaimTypes.IdRol);
            var nombre = principal.FindFirstValue(JWTClaimTypes.nombre);
            var TipoDocumento = principal.FindFirstValue(JWTClaimTypes.TipoDocumento);
            var NumeroDocumento = principal.FindFirstValue(JWTClaimTypes.NumeroDocumento);
            var Direccion = principal.FindFirstValue(JWTClaimTypes.Direccion);
            var Telefono = principal.FindFirstValue(JWTClaimTypes.Telefono);
            var Estado = principal.FindFirstValue(JWTClaimTypes.Estado);
            var tipo_rol = principal.FindFirstValue(JWTClaimTypes.tipo_rol);
            var descripcion_rol = principal.FindFirstValue(JWTClaimTypes.descripcion_rol);
            var email = principal.FindFirstValue(JWTClaimTypes.email);
            return new UserMeResult(Convert.ToInt32(IdRol), nombre, TipoDocumento, NumeroDocumento, Direccion, Telefono, Convert.ToBoolean(Estado), tipo_rol, descripcion_rol, email);
          
        }

    }
}
