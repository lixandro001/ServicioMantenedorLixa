using Domain.Entities;
using Domain.Enumerations;
using Domain.Results.Categoria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
  public interface IReportes
    {
       (ServiceStatus, string, byte[]) Excel(List<CategoriaResponseAll> list);
      
    }
}
