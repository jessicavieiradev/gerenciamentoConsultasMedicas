using sistemaAgendamentoMedico.DTOs.Auth.Request;
using sistemaAgendamentoMedico.DTOs.Auth.Response;
using sistemaAgendamentoMedico.DTOs.Shared;

namespace sistemaAgendamentoMedico.Interfaces
{
    public interface IAuthService
    {
        public Task<Result<AuthResponse>> RegistrarPaciente(RegistrarPacienteRequest request);

        public Task<Result<AuthResponse>> LoginPaciente(LoginRequest request);
    }
}
