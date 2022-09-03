using Application.Interfaces.IRepositories;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Categoria;
using Domain.Results.Categoria;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    class CategoriaRepository : ICategoriaRepository
    {
        private readonly string connectionString;
        private readonly string storeSchema;
        private readonly int Number;

        public CategoriaRepository(IConfiguration configuration)
        {
            Number = 12;
            connectionString = configuration.GetConnectionString("DBConnection"); //para obtener la cadena conexion 
        }
         
        public async Task<(ServiceStatus, string, Pagination<CategoriaResponse>)> GetListCategoria(string query, string user, int? page = 1)
        {
            var list = new List<CategoriaResponse>();
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
                        new SqlParameter{ ParameterName = "@nombre", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = value },
                       // new SqlParameter{ ParameterName = "@", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = user },  
                   };

                    var Dr = Ado.ExecDataReaderProc("usp_listado_Categoria", Parameters);

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

                        var entity = new CategoriaResponse();

                        if (Dr["idcategoria"] != DBNull.Value) { entity.idcategoria = Convert.ToInt32(Dr["idcategoria"]); }
                        if (Dr["nombreCategoria"] != DBNull.Value) { entity.nombreCategoria = (string)Dr["nombreCategoria"]; }
                        if (Dr["descripcion"] != DBNull.Value) { entity.descripcion = (string)Dr["descripcion"]; }
                        if (Dr["nombreEstado"] != DBNull.Value) { entity.nombreEstado = (string)Dr["nombreEstado"]; }
                        if (Dr["estado"] != DBNull.Value) { entity.estado = (bool)Dr["estado"]; }

                        //if (entity.estado == false)
                        //{
                        //    return (ServiceStatus.Status, "Categoria Inactiva", null);
                        //} 


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

            return (ServiceStatus.Ok, null, new Pagination<CategoriaResponse>(page.Value, Int32.Parse(total.ToString()), Number, list));
        }


        public async Task<(ServiceStatus, string, List<CategoriaResponse>)> GetListCategoriaCombo()
        {
            var list = new List<CategoriaResponse>();
            using (var Ado = new Ado.SQLServer(connectionString))
            {
                try
                {
                    var Dr = Ado.ExecDataReaderProc("usp_listar_categoria_combo", null);
                    if (Dr.HasRows == false)
                    {
                        return (ServiceStatus.FailedValidation, "no hay datos", null);
                    }

                    while (Dr.Read())
                    {  
                        var entity = new CategoriaResponse();

                        if (Dr["idcategoria"] != DBNull.Value) { entity.idcategoria = Convert.ToInt32(Dr["idcategoria"]); }
                        if (Dr["nombre"] != DBNull.Value) { entity.nombreCategoria = (string)Dr["nombre"]; }
                        if (Dr["descripcion"] != DBNull.Value) { entity.descripcion = (string)Dr["descripcion"]; }
                        
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



        public async Task<(ServiceStatus, string, DetalleCategoriaResponse)> GetDetalleCategoria(int idcategoria)
         {
            var detalle = new DetalleCategoriaResponse();

            using (var Ado = new Ado.SQLServer(connectionString))
            {
                try
                {
                    var Parameters = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName = "@idcategoria", SqlDbType = SqlDbType.Int, SqlValue = idcategoria},
                    };

                    var Dr = Ado.ExecDataReaderProc("sp_detalle_categoria", Parameters);

                    while (Dr.Read())
                    { 
                        if (Dr["nombre"] != DBNull.Value) { detalle.nombre = (string)(Dr["nombre"]); }
                        if (Dr["descripcion"] != DBNull.Value) { detalle.descripcion = (string)Dr["descripcion"]; }
                        if (Dr["estado"] != DBNull.Value) { detalle.estado = (bool)Dr["estado"]; }
                       
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

            return (ServiceStatus.Ok, null, detalle);
         }
         
        public async Task<(ServiceStatus,string)> AddNewCategory(NewCategory request)
        {
            try
            {
                using (var Ado = new Ado.SQLServer(connectionString))
                {
                    var Parameters = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName = "@nombre", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.nombre },
                        new SqlParameter{ ParameterName = "@descripcion", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.descripcion },
                        new SqlParameter { ParameterName = "@mensaje", SqlDbType = SqlDbType.VarChar,Size=50, SqlValue = "", Direction= ParameterDirection.InputOutput},
                        new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Int,SqlValue=0, Direction= ParameterDirection.InputOutput},

                    };

                    var Dr = Ado.ExecNonQueryProc("usp_agregar_categoria", Parameters);

                    var mensaje = Convert.ToString(Parameters[2].Value);
                    var valor = Convert.ToInt32(Parameters[3].Value);

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

        public async Task<(ServiceStatus, string)> DeleteCategory(DeleteCategory request)
        {
            try
            {
                using (var Ado = new Ado.SQLServer(connectionString))
                {
                    var Parameters = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName = "@idcategoria", SqlDbType = SqlDbType.Int, SqlValue = request.IdCategory },
                        new SqlParameter { ParameterName = "@mensaje", SqlDbType = SqlDbType.VarChar,Size=50, SqlValue = "", Direction= ParameterDirection.InputOutput},
                        new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Int,SqlValue=0, Direction= ParameterDirection.InputOutput},

                    };

                    var Dr = Ado.ExecNonQueryProc("usp_eliminar_categoria", Parameters);

                    var mensaje = Convert.ToString(Parameters[1].Value);
                    var valor = Convert.ToInt32(Parameters[2].Value);

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


        public async Task<(ServiceStatus, string, List<CategoriaResponseAll>)> GetExportarExcel()
        {
            var list = new List<CategoriaResponseAll>();
          
       
            using (var Ado = new Ado.SQLServer(connectionString))
            {
                try
                {
                    var Dr = Ado.ExecDataReaderProc("usp_excel_categoria", null);

                    if (Dr.HasRows == false)
                    {
                        return (ServiceStatus.FailedValidation, "no hay datos", null);
                    }

                    while (Dr.Read())
                    {
                        var entity = new CategoriaResponseAll();

                        if (Dr["idcategoria"] != DBNull.Value) { entity.idcategoria = (int)(Dr["idcategoria"]); }
                        if (Dr["nombre"] != DBNull.Value) { entity.nombre = (string)Dr["nombre"]; }
                        if (Dr["descripcion"] != DBNull.Value) { entity.descripcion = (string)Dr["descripcion"]; }
                        if (Dr["estado"] != DBNull.Value) { entity.estado = (bool)Dr["estado"]; }
                        //if (Dr["fechaRegistro"] != DBNull.Value) { entity.fechaRegistro = (string)(Dr["fechaRegistro"]); }

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

            return (ServiceStatus.Ok, null , list);
        }

    }
}