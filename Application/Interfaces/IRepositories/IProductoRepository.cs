using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Producto;
using Domain.Results.Producto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
   public interface IProductoRepository
    {
        Task<(ServiceStatus, string, Pagination<ProductoResponse>)> GetListProductos(string query, string user, int? page = 1);

        Task<(ServiceStatus, string)> AddNewProducto(NewProducto request);

        Task<(ServiceStatus, string)> DeleteProducto(DeleteProducto request);
    }
}
