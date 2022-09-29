using Application.Interfaces.IServices;
using Domain.Payloads.Conductor;
using Domain.Payloads.Vehiculo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serviciosMantenimiento.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        private readonly IConductorService conductorService;

        public ConductorController(IConductorService conductorService)
        {
            this.conductorService = conductorService;
        }

        [HttpPost("agregar-conductor")]
        public async Task<ActionResult> AgregarConductor ([FromBody] NuevoConductor request)
        {
            return Ok(await conductorService.AgregarConductor(request));
        }

        [HttpPost("agregar-vehiculo")]
        public async Task<ActionResult> AgregarVehiculo([FromBody] NuevoVehiculo request)
        {
            return Ok(await conductorService.AgregarVehiculo(request));
        }


    }
}
