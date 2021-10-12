using Application.Helpers;
using Application.Interfaces;
using Domain.Configurations;
using Domain.Entities;
using Domain.Results.Auths;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Securities
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly string _KeySecurity;
        private readonly TokenManagement tokenSettings;

        public JwtGenerator(IConfiguration configuration,
            IOptions<TokenManagement> tokenSettings)
        {
            _KeySecurity = configuration["KeySecurity"];
            this.tokenSettings = tokenSettings.Value;
        }

        public async Task<AuthResult> CreateToken(UserMe auth)
        {

            var claims = new[] {

                new Claim(JWTClaimTypes.IdRol, Convert.ToString(auth.IdRol)),
                new Claim(JWTClaimTypes.nombre, auth.nombre),
                new Claim(JWTClaimTypes.TipoDocumento, auth.TipoDocumento),
                new Claim(JWTClaimTypes.NumeroDocumento, auth.NumeroDocumento),
                new Claim(JWTClaimTypes.Direccion, auth.Direccion),
                new Claim(JWTClaimTypes.Telefono, auth.Telefono),
                new Claim(JWTClaimTypes.Estado, Convert.ToString(auth.Estado)),
                new Claim(JWTClaimTypes.tipo_rol, Convert.ToString(auth.tipo_rol)),
                new Claim(JWTClaimTypes.descripcion_rol, Convert.ToString(auth.descripcion_rol)),
                new Claim(JWTClaimTypes.email, Convert.ToString(auth.email)),


            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));
            var encryptingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.EncryptionSecret));

            var now = DateTime.UtcNow;
            var expiresAt = DateTime.UtcNow.AddMinutes(tokenSettings.AccessExpiration);

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var encryptingCredentials = new EncryptingCredentials(encryptingKey, SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.CreateJwtSecurityToken(
                tokenSettings.Issuer,
                tokenSettings.Audience,
                new ClaimsIdentity(claims),
                now,
                expiresAt,
                now,
                signingCredentials: signingCredentials,
                encryptingCredentials: encryptingCredentials
            );

            var token = await Task.Run(() => handler.WriteToken(jwtSecurityToken));
            var expirationTimestamp = DateTimeHelper.GetUnixTimeMilliseconds(expiresAt);

            return new AuthResult(token, expirationTimestamp);
        }

        public static class JWTClaimTypes
        {
            public const string IdRol = "https://suiza-result/IdRol";
            public const string nombre = "https://suiza-result/nombre";
            public const string TipoDocumento = "https://suiza-result/TipoDocumento";
            public const string NumeroDocumento = "https://suiza-result/NumeroDocumento";
            public const string Direccion = "https://suiza-result/Direccion";
            public const string Telefono = "https://suiza-result/Telefono";
            public const string Estado = "https://suiza-result/Estado";
            public const string tipo_rol = "https://suiza-result/tipo_rol";
            public const string descripcion_rol = "https://suiza-result/descripcion_rol";
            public const string email = "https://suiza-result/email";
        }
    }
}
