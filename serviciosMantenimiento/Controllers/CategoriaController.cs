using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using serviciosMantenimiento.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Results.Categoria;
using Domain.Payloads.Categoria;

namespace serviciosMantenimiento.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }
      
        [HttpGet("listado-categoria")]
        public async Task<IActionResult> GetListCategoria([FromQuery(Name = "query")] string query, [FromQuery] int? page = 1)
        {
            var me = User.GetUser();
            var user = me.email;
            return Ok(await categoriaService.GetListCategoria(query, user, page));
        }


        [HttpPost("agregar-categoria")]
        public async Task<ActionResult> AddNewCategory(NewCategory request)
        {
            return Ok(await categoriaService.AddNewCategory(request));
        }

        [HttpPost("eliminar-categoria")]
        public async Task<ActionResult> DeleteCategory(DeleteCategory request)
        {
            return Ok(await categoriaService.DeleteCategory(request));
        }

        [HttpGet("exportar-excel")]
        public async Task<IActionResult> GetExportarExcel()
        {
            var excel = await categoriaService.GetExportarExcel();

            return new FileContentResult(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "excel.xlsx"
            };
        }

        [HttpGet("exportar-excel-base64")]
        public async Task<IActionResult> GetExportarExcelBase64()
        {
            var excel = await categoriaService.GetExportarExcel();

            CategoriaExcelResponse CategoriaExcelResponse = new CategoriaExcelResponse();
            CategoriaExcelResponse.Excel = excel;
            return Ok(CategoriaExcelResponse);
        }

        [HttpGet("Obtener-detalle-categoria")]
        public async Task<IActionResult> GetDetalleCategoria([FromQuery(Name = "idcategoria")] int idcategoria)
        {
            return Ok(await categoriaService.GetDetalleCategoria(idcategoria));           
        }
    }
}
