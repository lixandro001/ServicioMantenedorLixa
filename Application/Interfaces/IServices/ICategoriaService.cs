using Domain.Entities;
using Domain.Payloads.Categoria;
using Domain.Results;
using Domain.Results.Categoria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces.IServices
{
    public interface ICategoriaService
    {
        Task<Pagination<CategoriaResponse>> GetListCategoria(string query, string user, int? page);

        Task<List<CategoriaResponse>> GetListCategoriaCombo();

        Task<DetalleCategoriaResponse> GetDetalleCategoria(int idcategoria);

        Task<byte[]> GetExportarExcel();
        Task<MessageResult> AddNewCategory(NewCategory request);
        Task<MessageResult> DeleteCategory(DeleteCategory request);
    }
}
