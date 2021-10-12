using Application.Interfaces;
using Domain.Enumerations;
using Domain.Results.Categoria;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Report.Templates
{
   public class ReporteDatosCategoria: IReportes
    {
  
        private readonly IHostingEnvironment HostingEnvironment;

        public ReporteDatosCategoria( IHostingEnvironment IHostingEnvironment)
        {
             
            HostingEnvironment = IHostingEnvironment;
        }

        public (ServiceStatus, string, byte[]) Excel(List<CategoriaResponseAll> list)
        {
            try
            {
                var rutaFichero = @"\\192.168.0.15\soft";
                string FileName = string.Format("ReportCategoria_{0:ddMMyyyy_hhmmss}.xlsx", DateTime.Now);

                string PathTemplate = Path.Combine(rutaFichero, "FORMATOLIXANDRO/reportecategoria.xlsx");
                string NewPath = Path.Combine(rutaFichero, "LIXANDRO/" + FileName);
                byte[] variable;

                using (var pck = new OfficeOpenXml.ExcelPackage())
                {
                    using (var stream = System.IO.File.OpenRead(PathTemplate))
                    {
                        pck.Load(stream);
                    }

                    var ws = pck.Workbook.Worksheets["Data"];

                    int Position = 2;
                    foreach (var itm in list)
                    {
                        ws.Cells[Position, 1].Value = itm.idcategoria;
                        ws.Cells[Position, 2].Value = itm.nombre;
                        ws.Cells[Position, 3].Value = itm.descripcion;
                        ws.Cells[Position, 4].Value = itm.estado;
                       // ws.Cells[Position, 5].Value = itm.fechaRegistro;    
                        Position++;
                    }

                    pck.SaveAs(new FileInfo(NewPath));
                    byte[] FileBytes = System.IO.File.ReadAllBytes(NewPath);

                    variable = FileBytes;

                    return (ServiceStatus.Ok, null, variable);
                }
            }
            catch (Exception e)
            {
                return (ServiceStatus.InternalError, e.Message, null);
            }
        }





    }
}
