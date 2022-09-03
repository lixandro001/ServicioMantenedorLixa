using Application.Interfaces.IServices;
using Domain.Payloads.Producto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using serviciosMantenimiento.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serviciosMantenimiento.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServices productoServices;

        public ProductoController(IProductoServices productoServices)
        {
            this.productoServices = productoServices;
        }

        [HttpGet("listado-producto")]
        public async Task<IActionResult> GetListProductos([FromQuery(Name = "query")] string query, [FromQuery] int? page = 1)
        {
            var me = User.GetUser();
            var user = me.email;
            return Ok(await productoServices.GetListProductos(query, user, page));
        }
         
        [HttpPost("agregar-producto")]
        public async Task<IActionResult> AddNewProducto(NewProducto request)
        {
            return Ok(await productoServices.AddNewProducto(request));
        }

        [HttpPost("eliminar-producto")]
        public async Task<ActionResult> DeleteProducto(DeleteProducto request)
        {
            return Ok(await productoServices.DeleteProducto(request));
        }
         
         
    }    
}
