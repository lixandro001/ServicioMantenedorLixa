using Application.Interfaces.IServices;
using Domain.Payloads.Conductor;
using Domain.Payloads.Vehiculo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using serviciosMantenimiento.Authentications;
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



        [HttpPost("agregar-asignacion-horarios-dias")]
        public async Task<ActionResult> AgregarAsignacionHorariosDias([FromBody] NuevaAsignaciomHorariosDias request)
        {
            return Ok(await conductorService.AgregarAsignacionHorariosDias(request));
        }


        [HttpGet("listado-conductor")]
        public async Task<IActionResult> GetListConductor([FromQuery(Name = "query")] string query, [FromQuery] int? page = 1)
        {
            var me = User.GetUser();
            var user = me.email;
            return Ok(await conductorService.GetListConductor(query, user, page));
        }


        [HttpGet("listado-vehiculo")]
        public async Task<IActionResult> GetListVehiculo([FromQuery(Name = "query")] string query, [FromQuery] int? page = 1)
        {
            var me = User.GetUser();
            var user = me.email;
            return Ok(await conductorService.GetListVehiculo(query, user, page));
        }

        [HttpPost("asignar-vehiculos")]
        public async Task<ActionResult> AsignacionVehiculos(AsignacionVehiculos request)
        {
            return Ok(await conductorService.AsignacionVehiculos(request));
        }
         
        [HttpGet("listado-rutas-combo")]
        public async Task<IActionResult> GetListRutaCombo()
        {
            var me = User.GetUser();
            var user = me.email;
            return Ok(await conductorService.GetListRutaCombo());
        }




    }
}
