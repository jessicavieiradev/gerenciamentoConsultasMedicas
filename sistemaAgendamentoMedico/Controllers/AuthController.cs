using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sistemaAgendamentoMedico.DTOs.Auth.Request;
using sistemaAgendamentoMedico.Interfaces;

namespace sistemaAgendamentoMedico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController<AuthController>
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("teste")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok("teste feito");
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar([FromBody] RegistrarPacienteRequest request)
        {
            var resultado = await _authService.RegistrarPaciente(request);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado);
            }
            return Ok(resultado);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var resultado = await _authService.LoginPaciente(request);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado);
            }
            return Ok(resultado);
        }
    }
}
