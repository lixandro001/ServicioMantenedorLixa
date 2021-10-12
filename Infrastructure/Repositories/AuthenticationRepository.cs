using Application.Interfaces.IRepositories;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Auths;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
    class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly string connectionString;   
        private readonly string storeSchema;
       // private readonly IConfiguration Configuration;

        public AuthenticationRepository(IConfiguration configuration)
        {         
            connectionString = configuration.GetConnectionString("DBConnection"); //para obtener la cadena conexion 
        }     
         
        public async Task<(ServiceStatus, string, UserMe)> Auth(AuthPayload payload)
        {
            //var user = new UserMe(payload.Username, payload.Password);
            //payload.Password = SecurityHelper.Encriptar(payload.Password.ToUpper());

            var user = new UserMe();

            using (var Ado = new Ado.SQLServer(connectionString))
            {
                try
                {
                    var Parameters = new SqlParameter[]
                   {
                        new SqlParameter{ ParameterName = "@usuario", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = payload.Username },
                        new SqlParameter{ ParameterName = "@password", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = payload.Password }
                   };

                    var Dr = Ado.ExecDataReaderProc("usp_login", Parameters);

                    if (Dr.HasRows==false)
                    {
                        return (ServiceStatus.FailedValidation, "usuario invalido", null);
                    }

                 
                    while (Dr.Read())
                    {
                        // Entity = new UserResponseBE();
                        if (Dr["idrol"] != DBNull.Value) { user.IdRol = Convert.ToInt32(Dr["idrol"]); }
                        if (Dr["nombre"] != DBNull.Value) { user.nombre = (string)Dr["nombre"]; }
                        if (Dr["tipo_documento"] != DBNull.Value) { user.TipoDocumento = (string)Dr["tipo_documento"]; }
                        if (Dr["num_documento"] != DBNull.Value) { user.NumeroDocumento = (string)Dr["num_documento"]; }
                        if (Dr["direccion"] != DBNull.Value) { user.Direccion = (string)Dr["direccion"]; }
                        if (Dr["telefono"] != DBNull.Value) { user.Telefono = (string)Dr["telefono"]; }
                        if (Dr["estado"] != DBNull.Value) { user.Estado = (bool)Dr["estado"]; }
                        if (Dr["tipo_rol"] != DBNull.Value) { user.tipo_rol = (string)Dr["tipo_rol"]; }
                        if (Dr["descripcion_rol"] != DBNull.Value) { user.descripcion_rol = (string)Dr["descripcion_rol"]; }
                        if (Dr["email"] != DBNull.Value) { user.email = (string)Dr["email"]; }

                        if (user.Estado == false)
                        {
                            return (ServiceStatus.Status, "usuario inactivo", null);
                        }

                        break;
                    }

                    Dr.Close();                
                }
                catch (Exception ex)
                {
                    return (ServiceStatus.InternalError, $"Problemas Internos de aplicación... { ex.Message }", null);
                }
            }
     
            await Task.Delay(1);

            return (ServiceStatus.Ok, null, user);
        }
    }
}
