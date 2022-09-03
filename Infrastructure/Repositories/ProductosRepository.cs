using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Producto;
using Domain.Results.Producto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
   public class ProductosRepository: IProductoRepository
    {
        private readonly string connectionString;
        private readonly string storeSchema;
        private readonly int Number;

        public ProductosRepository(IConfiguration configuration)
        {
            Number = 12;
            connectionString = configuration.GetConnectionString("DBConnection"); //para obtener la cadena conexion 
        }


        public async Task<(ServiceStatus, string, Pagination<ProductoResponse>)> GetListProductos(string query, string user, int? page = 1)
        {
            var list = new List<ProductoResponse>();
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

                    var Dr = Ado.ExecDataReaderProc("usp_listar_productos", Parameters);

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

                        var entity = new ProductoResponse();

                        if (Dr["idarticulo"] != DBNull.Value) { entity.idarticulo = Convert.ToInt32(Dr["idarticulo"]); }
                        if (Dr["idcategoria"] != DBNull.Value) { entity.idcategoria = (int)Dr["idcategoria"]; }
                        if (Dr["codigo"] != DBNull.Value) { entity.codigo = (string)Dr["codigo"]; }
                        if (Dr["nombreArticulo"] != DBNull.Value) { entity.nombreArticulo = (string)Dr["nombreArticulo"]; }
                        if (Dr["precio_venta"] != DBNull.Value) { entity.precio_venta = (decimal)Dr["precio_venta"]; }
                        if (Dr["stock"] != DBNull.Value) { entity.stock = (int)Dr["stock"]; }
                        if (Dr["descripcionArticulo"] != DBNull.Value) { entity.descripcionArticulo = (string)Dr["descripcionArticulo"]; }
                        if (Dr["nombreCategoria"] != DBNull.Value) { entity.nombreCategoria = (string)Dr["nombreCategoria"]; }
                        if (Dr["descripcionCategoria"] != DBNull.Value) { entity.descripcionCategoria = (string)Dr["descripcionCategoria"]; }

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

            return (ServiceStatus.Ok, null, new Pagination<ProductoResponse>(page.Value, Int32.Parse(total.ToString()), Number, list));
        }


        public async Task<(ServiceStatus, string)> AddNewProducto(NewProducto request)
        {
            try
            {
                using (var Ado = new Ado.SQLServer(connectionString))
                {
                    var Parameters = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName = "@idcategoria", SqlDbType = SqlDbType.Int, SqlValue = request.idcategoria },
                        new SqlParameter{ ParameterName = "@nombre", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.nombre },
                        new SqlParameter{ ParameterName = "@precio_venta", SqlDbType = SqlDbType.Decimal, SqlValue = request.precio_venta },
                        new SqlParameter{ ParameterName = "@stock", SqlDbType = SqlDbType.Int, Size= 200, SqlValue = request.stock },
                        new SqlParameter{ ParameterName = "@descripcion", SqlDbType = SqlDbType.VarChar, Size= 200, SqlValue = request.descripcion },
                        new SqlParameter { ParameterName = "@mensaje", SqlDbType = SqlDbType.VarChar,Size=50, SqlValue = "", Direction= ParameterDirection.InputOutput},
                        new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Int,SqlValue=0, Direction= ParameterDirection.InputOutput},
                    };

                    var Dr = Ado.ExecNonQueryProc("usp_agregar_producto", Parameters);
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

         
        public async Task<(ServiceStatus, string)> DeleteProducto(DeleteProducto request)
        {
            try
            {
                using (var Ado = new Ado.SQLServer(connectionString))
                {
                    var Parameters = new SqlParameter[]
                    {
                        new SqlParameter{ ParameterName = "@idarticulo", SqlDbType = SqlDbType.Int, SqlValue = request.idArticulo },
                        new SqlParameter { ParameterName = "@mensaje", SqlDbType = SqlDbType.VarChar,Size=50, SqlValue = "", Direction= ParameterDirection.InputOutput},
                        new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Int,SqlValue=0, Direction= ParameterDirection.InputOutput},
                    };

                    var Dr = Ado.ExecNonQueryProc("usp_eliminar_producto", Parameters);
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
    }
}
