using Domain.Entities;
using Domain.Payloads.Producto;
using Domain.Results;
using Domain.Results.Producto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IProductoServices
    {
        Task<Pagination<ProductoResponse>> GetListProductos(string query, string user, int? page);
        Task<MessageResult> AddNewProducto(NewProducto request);
        Task<MessageResult> DeleteProducto(DeleteProducto request);
    }
}
