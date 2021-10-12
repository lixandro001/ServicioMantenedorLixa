using Application.Interfaces.IServices;
using Domain.Payloads.Auths;
using Microsoft.AspNetCore.Mvc;
using serviciosMantenimiento.Authentications;
using System.Threading.Tasks;


namespace serviciosMantenimiento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
 
        public AuthController(IAuthenticationService authenticationService)
        {         
            this.authenticationService = authenticationService;    
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthPayload payload)
        {
            return Ok(await authenticationService.Auth(payload));
        }
  

    }
}
