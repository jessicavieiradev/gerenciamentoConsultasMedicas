using Microsoft.AspNetCore.Mvc;

namespace sistemaAgendamentoMedico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController<AuthController>
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("AuthController funcionando!");
        }
    }
}
