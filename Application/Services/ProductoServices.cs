using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Producto;
using Domain.Results;
using Domain.Results.Producto;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public  class ProductoServices: IProductoServices
    {
        private readonly IProductoRepository productoRepository;
        
        public ProductoServices(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;   
        }

        public async Task<Pagination<ProductoResponse>> GetListProductos(string query, string user, int? page)
        {
            var (status, message, result) = await productoRepository.GetListProductos(query, user, page);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );
            return result;
        }
 
        public async Task<MessageResult> AddNewProducto(NewProducto request)
        {
            var (status, message) = await productoRepository.AddNewProducto(request);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );
            return MessageResult.Of(message);
        }
        
        public async Task<MessageResult> DeleteProducto(DeleteProducto request)
        {
            var (status, message) = await productoRepository.DeleteProducto(request);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );
            return MessageResult.Of(message);
        }


    }
}
