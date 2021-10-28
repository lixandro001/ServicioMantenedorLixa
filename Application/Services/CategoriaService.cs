using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Payloads.Categoria;
using Domain.Results;
using Domain.Results.Categoria;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository categoriaRepository;
        private readonly IReportes Reportes;

        public CategoriaService(ICategoriaRepository categoriaRepository, IReportes Reportes)
        {
            this.categoriaRepository = categoriaRepository;
            this.Reportes = Reportes;
        }


        public async Task<Pagination<CategoriaResponse>> GetListCategoria(string query, string user, int? page)
        {
            var (status, message, result) = await categoriaRepository.GetListCategoria(query, user, page);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return result;
        }

         public async  Task<DetalleCategoriaResponse> GetDetalleCategoria(int idcategoria)
         {
            var (status, message, result) = await categoriaRepository.GetDetalleCategoria(idcategoria);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return result;
        }


        public async Task<MessageResult> AddNewCategory(NewCategory request)
        {
            var (status, message) = await categoriaRepository.AddNewCategory(request);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return MessageResult.Of(message);
        }

        public async Task<MessageResult> DeleteCategory(DeleteCategory request)
        {
            var (status, message) = await categoriaRepository.DeleteCategory(request);

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

            return MessageResult.Of(message);
        }

        public async Task<byte[]> GetExportarExcel()
        {
            var (status, message, result) = await categoriaRepository.GetExportarExcel();

            if (status != ServiceStatus.Ok)
                throw new ErrorHandler(
                        status == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , message
                    );

         
            var (statusExcel, messageExcel, resultExcel) =  Reportes.Excel(result);

            if (statusExcel != ServiceStatus.Ok)
                throw new ErrorHandler(
                        statusExcel == ServiceStatus.FailedValidation
                        ? HttpStatusCode.BadRequest
                        : HttpStatusCode.InternalServerError
                    , messageExcel
                    );

            //var resultExcel = _mapper.Map<ExportCommissionReportDto>(response);
             
            return resultExcel;
        }




        
    }
}
