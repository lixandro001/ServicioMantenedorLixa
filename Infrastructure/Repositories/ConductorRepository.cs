using Application.Interfaces.IRepositories;
using Domain.Enumerations;
using Domain.Payloads.Conductor;
using Domain.Payloads.Vehiculo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ConductorRepository : IConductorRepository
    {
        private readonly string connectionString;
        private readonly string storeSchema;
        private readonly int Number;

        public ConductorRepository(IConfiguration configuration)
        {
            Number = 12;
            connectionString = configuration.GetConnectionString("DBConnection"); //para obtener la cadena conexion 
        }

        public async Task<(ServiceStatus, string)> AgregarConductor(NuevoConductor request)
        {
            try
            {
                using (var Ado = new Ado.SQLServer(connectionString))
                {
                    var Parameters = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName = "@IdSexo", SqlDbType = SqlDbType.Int,   SqlValue = request.IdSexo },
                        new SqlParameter{ ParameterName = "@idusuario", SqlDbType = SqlDbType.VarChar,Size=100,   SqlValue = request.idusuario },
                        new SqlParameter{ ParameterName = "@Apellido", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.Apellido },
                        new SqlParameter{ ParameterName = "@NombreCompleto", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.NombreCompleto },
                        new SqlParameter{ ParameterName = "@Dni", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.Dni },
                        new SqlParameter{ ParameterName = "@FechaNcimiento", SqlDbType = SqlDbType.DateTime , SqlValue = request.FechaNcimiento },
                        new SqlParameter{ ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.Direccion },
                        new SqlParameter{ ParameterName = "@NumeroLicencia", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.NumeroLicencia },
                        new SqlParameter{ ParameterName = "@FechaExpedicion", SqlDbType = SqlDbType.DateTime,  SqlValue = request.FechaExpedicion },
                        new SqlParameter{ ParameterName = "@Telefono", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.Telefono },
                        new SqlParameter{ ParameterName = "@Correo", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.Correo },
                        new SqlParameter{ ParameterName = "@LicenciaValidada", SqlDbType = SqlDbType.Bit,   SqlValue = request.LicenciaValidada },
                        new SqlParameter { ParameterName = "@mensaje", SqlDbType = SqlDbType.VarChar,Size=50, SqlValue = "", Direction= ParameterDirection.InputOutput},
                        new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Int,SqlValue=0, Direction= ParameterDirection.InputOutput},
                    };

                    var Dr = Ado.ExecNonQueryProc("sp_guardarConductor", Parameters);
                    var mensaje = Convert.ToString(Parameters[12].Value);
                    var valor = Convert.ToInt32(Parameters[13].Value);

                    if (valor == 0)
                    {
                        return (ServiceStatus.FailedValidation, mensaje);
                    }

                    await Task.Delay(1);
                    return (ServiceStatus.Ok, mensaje);
                }

            }
            catch (Exception e)
            {
                return (ServiceStatus.InternalError, e.Message);
            }
        }
         

        public async Task<(ServiceStatus, string)> AgregarVehiculo(NuevoVehiculo request)
        {
            try
            {
                using (var Ado = new Ado.SQLServer(connectionString))
                {
                    var Parameters = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName = "@usuario", SqlDbType = SqlDbType.VarChar,Size=100,  SqlValue = request.usuario },
                        new SqlParameter{ ParameterName = "@modelo", SqlDbType = SqlDbType.VarChar,Size=100,   SqlValue = request.modelo },
                        new SqlParameter{ ParameterName = "@placa", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.placa },
                        new SqlParameter{ ParameterName = "@fechaCompra", SqlDbType = SqlDbType.DateTime, SqlValue = request.fechaCompra },
                        new SqlParameter{ ParameterName = "@serie", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.serie },   
                        new SqlParameter { ParameterName = "@mensaje", SqlDbType = SqlDbType.VarChar,Size=50, SqlValue = "", Direction= ParameterDirection.InputOutput},
                        new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Int,SqlValue=0, Direction= ParameterDirection.InputOutput},
                    };

                    var Dr = Ado.ExecNonQueryProc("usp_Guardar_Vehiculo", Parameters);
                    var mensaje = Convert.ToString(Parameters[5].Value);
                    var valor = Convert.ToInt32(Parameters[6].Value);

                    if (valor == 0)
                    {
                        return (ServiceStatus.FailedValidation, mensaje);
                    }

                    await Task.Delay(1);
                    return (ServiceStatus.Ok, mensaje);
                }

            }
            catch (Exception e)
            {
                return (ServiceStatus.InternalError, e.Message);
            }
        }

    }
}
