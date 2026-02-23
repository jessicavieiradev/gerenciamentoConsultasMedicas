using Microsoft.AspNetCore.Mvc;

namespace sistemaAgendamentoMedico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : BaseController<AgendamentoController>
    {
        [HttpGet]
        public IActionResult GetAgendamentos()
        {
            Logger.LogInformation("Teste funcionamento Serilog");
            return Ok("Lista de agendamentos");
        }
    }
}
