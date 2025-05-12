using Microsoft.AspNetCore.Mvc;
using Practica3.Api.Models;

namespace Practica3.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientCodeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<PatientCodeResponse> Get(
            [FromQuery] string name,
            [FromQuery] string lastName,
            [FromQuery] string ci)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(ci))
            {
                return BadRequest("name, lastName and ci are required");
            }

            var initials = $"{name[0]}{lastName[0]}".ToUpper();
            var code = $"{initials}-{ci}";
            return Ok(new PatientCodeResponse(code));
        }
    }
}
