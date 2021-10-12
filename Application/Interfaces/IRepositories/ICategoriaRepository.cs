using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Categoria;
using Domain.Results.Categoria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
   public interface ICategoriaRepository
   {
        Task<(ServiceStatus, string, Pagination<CategoriaResponse>)> GetListCategoria(string query, string user, int? page = 1);
        Task<(ServiceStatus, string,  DetalleCategoriaResponse)> GetDetalleCategoria(int idcategoria);
        Task<(ServiceStatus, string, List<CategoriaResponseAll>)> GetExportarExcel();
        Task<(ServiceStatus, string)> AddNewCategory(NewCategory request);
   }
}
