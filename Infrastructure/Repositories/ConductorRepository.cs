using Application.Interfaces.IRepositories;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Conductor;
using Domain.Payloads.Vehiculo;
using Domain.Results.Conductor;
using Domain.Results.Ruta;
using Domain.Results.Vehiculo;
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


        public async Task<(ServiceStatus, string)> AgregarAsignacionHorariosDias(NuevaAsignaciomHorariosDias request)
        {
            try
            {
                using (var Ado = new Ado.SQLServer(connectionString))
                {
                    var Parameters = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName = "@IdUsuario", SqlDbType = SqlDbType.VarChar,Size=100, SqlValue = request.IdUsuario },
                        new SqlParameter{ ParameterName = "@IdConductor", SqlDbType = SqlDbType.Int, SqlValue = request.IdConductor },
                        new SqlParameter{ ParameterName = "@lunes", SqlDbType = SqlDbType.Bit, Size= 200, SqlValue = request.lunes },
                        new SqlParameter{ ParameterName = "@martes", SqlDbType = SqlDbType.Bit, SqlValue = request.martes },
                        new SqlParameter{ ParameterName = "@miercoles", SqlDbType = SqlDbType.Bit, Size= 200, SqlValue = request.miercoles },
                        new SqlParameter{ ParameterName = "@jueves", SqlDbType = SqlDbType.Bit, Size= 200, SqlValue = request.jueves },
                        new SqlParameter{ ParameterName = "@viernes", SqlDbType = SqlDbType.Bit, Size= 200, SqlValue = request.viernes },
                        new SqlParameter{ ParameterName = "@sabado", SqlDbType = SqlDbType.Bit, Size= 200, SqlValue = request.sabado },
                        new SqlParameter{ ParameterName = "@domingo", SqlDbType = SqlDbType.Bit, Size= 200, SqlValue = request.domingo },
                        new SqlParameter { ParameterName = "@mensaje", SqlDbType = SqlDbType.VarChar,Size=50, SqlValue = "", Direction= ParameterDirection.InputOutput},
                        new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Int,SqlValue=0, Direction= ParameterDirection.InputOutput},
                    };

                    var Dr = Ado.ExecNonQueryProc("sp_Guardar_Horarios_Conductores", Parameters);
                    var mensaje = Convert.ToString(Parameters[9].Value);
                    var valor = Convert.ToInt32(Parameters[10].Value);

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
         

        public async Task<(ServiceStatus, string)> AsignacionVehiculos(AsignacionVehiculos request)
        {
            try
            {
                using (var Ado = new Ado.SQLServer(connectionString))
                {
                    var Parameters = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName = "@idvehiculo", SqlDbType = SqlDbType.Int, SqlValue = request.idvehiculo },
                        new SqlParameter{ ParameterName = "@idconductor", SqlDbType = SqlDbType.Int, SqlValue = request.idconductor },
                        new SqlParameter{ ParameterName = "@duenoVehiculo", SqlDbType = SqlDbType.Bit, SqlValue = request.duenoVehiculo },
                        new SqlParameter { ParameterName = "@mensaje", SqlDbType = SqlDbType.VarChar,Size=50, SqlValue = "", Direction= ParameterDirection.InputOutput},
                        new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Int,SqlValue=0, Direction= ParameterDirection.InputOutput},

                    };

                    var Dr = Ado.ExecNonQueryProc("sp_Asignacion_Vehiculos", Parameters);

                    var mensaje = Convert.ToString(Parameters[3].Value);
                    var valor = Convert.ToInt32(Parameters[4].Value);

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

        public async Task<(ServiceStatus, string, Pagination<ConductorResponse>)> GetListConductor(string query, string user, int? page = 1)
        {
            var list = new List<ConductorResponse>();
            long total = 0;
            int start = (page.Value - 1) * Number;
            var value = query ?? "";

            if (user == "T")
            {
                user = "";
            }

            using (var Ado = new Ado.SQLServer(connectionString))
            {
                try
                {
                    var Parameters = new SqlParameter[]
                   {
                        new SqlParameter{ ParameterName = "@Dni", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = value },
                       
                   };

                    var Dr = Ado.ExecDataReaderProc("sp_Buscar_Conductor", Parameters);

                    if (Dr.HasRows == false)
                    {
                        return (ServiceStatus.FailedValidation, "no hay datos", null);
                    }


                    while (Dr.Read())
                    {

                        total++;

                        if (total <= start || total > start + Number)
                        {
                            continue;
                        }

                        var entity = new ConductorResponse();

                        if (Dr["Dni"] != DBNull.Value) { entity.Dni = (string)(Dr["Dni"]); }
                        if (Dr["Apellido"] != DBNull.Value) { entity.Apellido = (string)Dr["Apellido"]; }
                        if (Dr["NombreCompleto"] != DBNull.Value) { entity.NombreCompleto = (string)Dr["NombreCompleto"]; }
                        if (Dr["idConductor"] != DBNull.Value) { entity.idConductor = (int)Dr["idConductor"]; }
                        if (Dr["NumeroLicencia"] != DBNull.Value) { entity.NumeroLicencia = (string)Dr["NumeroLicencia"]; }

                         
                        list.Add(entity);
                    }

                    Dr.Close();
                }
                catch (Exception ex)
                {
                    return (ServiceStatus.InternalError, $"Problemas Internos de aplicación... { ex.Message }", null);
                }
            }
            await Task.Delay(1);

            return (ServiceStatus.Ok, null, new Pagination<ConductorResponse>(page.Value, Int32.Parse(total.ToString()), Number, list));
        }



        public async Task<(ServiceStatus, string, Pagination<VehiculoResponse>)> GetListVehiculo(string query, string user, int? page = 1)
        {
            var list = new List<VehiculoResponse>();
            long total = 0;
            int start = (page.Value - 1) * Number;
            var value = query ?? "";

            if (user == "T")
            {
                user = "";
            }

            using (var Ado = new Ado.SQLServer(connectionString))
            {
                try
                {
                    var Parameters = new SqlParameter[]
                   {
                        new SqlParameter{ ParameterName = "@Placa", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = value },

                   };

                    var Dr = Ado.ExecDataReaderProc("SP_Buscar_Vehiculo", Parameters);

                    if (Dr.HasRows == false)
                    {
                        return (ServiceStatus.FailedValidation, "no hay datos", null);
                    }


                    while (Dr.Read())
                    {

                        total++;

                        if (total <= start || total > start + Number)
                        {
                            continue;
                        }

                        var entity = new VehiculoResponse();

                        if (Dr["idVehiculo"] != DBNull.Value) { entity.idVehiculo = (int)(Dr["idVehiculo"]); }
                        if (Dr["modelo"] != DBNull.Value) { entity.modelo = (string)Dr["modelo"]; }
                        if (Dr["placa"] != DBNull.Value) { entity.placa = (string)Dr["placa"]; }
                        if (Dr["serie"] != DBNull.Value) { entity.serie = (string)Dr["serie"]; }


                        list.Add(entity);
                    }

                    Dr.Close();
                }
                catch (Exception ex)
                {
                    return (ServiceStatus.InternalError, $"Problemas Internos de aplicación... { ex.Message }", null);
                }
            }
            await Task.Delay(1);

            return (ServiceStatus.Ok, null, new Pagination<VehiculoResponse>(page.Value, Int32.Parse(total.ToString()), Number, list));
        }



        public async Task<(ServiceStatus, string, List<RutaResponse>)> GetListRutaCombo()
        {
            var list = new List<RutaResponse>();
            using (var Ado = new Ado.SQLServer(connectionString))
            {
                try
                {
                    var Dr = Ado.ExecDataReaderProc("SP_LISTA_RUTA", null);
                    if (Dr.HasRows == false)
                    {
                        return (ServiceStatus.FailedValidation, "no hay datos", null);
                    }

                    while (Dr.Read())
                    {
                        var entity = new RutaResponse();

                        if (Dr["IDRUTA"] != DBNull.Value) { entity.IDRUTA = Convert.ToInt32(Dr["IDRUTA"]); }
                        if (Dr["DETALLERUTA"] != DBNull.Value) { entity.DETALLERUTA = (string)Dr["DETALLERUTA"]; }
                       
                        list.Add(entity);
                    }

                    Dr.Close();
                }
                catch (Exception ex)
                {
                    return (ServiceStatus.InternalError, $"Problemas Internos de aplicación... { ex.Message }", null);
                }
            }
            await Task.Delay(1);

            return (ServiceStatus.Ok, null, list);
        }
         

    }
}
