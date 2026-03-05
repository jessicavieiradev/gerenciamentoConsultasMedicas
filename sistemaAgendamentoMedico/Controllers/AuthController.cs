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

        [HttpPost("registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> RegistrarPaciente([FromBody] RegistrarPacienteRequest request)
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
        public async Task<IActionResult> LoginPaciente([FromBody] LoginRequest request)
        {
            var resultado = await _authService.LoginPaciente(request);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado);
            }
            return Ok(resultado);
        }

        [HttpPost("medico/registrar")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegistrarMedico([FromBody] RegistrarMedicoRequest request)
        {
            var resultado = await _authService.RegistrarMedico(request);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado);
            }
            return Ok(resultado);
        }

        [HttpPost("medico/login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginMedico([FromBody] LoginMedico request)
        {
            var resultado = await _authService.LoginMedico(request);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado);
            }
            return Ok(resultado);
        }

        [HttpPost("admin/login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginAdmin request)
        {
            var resultado = await _authService.LoginAdmin(request);
            if (!resultado.Sucesso)
            {
                return BadRequest(resultado);
            }
            return Ok(resultado);

        }
    }
}
