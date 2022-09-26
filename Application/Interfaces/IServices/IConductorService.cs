using Domain.Payloads.Conductor;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
   public interface IConductorService
    {
        Task<MessageResult> AgregarConductor(NuevoConductor request);
    }
}
