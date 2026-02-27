using sistemaAgendamentoMedico.Entities;

namespace sistemaAgendamentoMedico.Interfaces
{
    public interface ITokenService
    {
        Task<string> GerarToken(Usuario usuario);
    }
}
