using Microsoft.AspNetCore.Identity;

namespace sistemaAgendamentoMedico.Entities
{
    public class Usuario : IdentityUser<long>
    {
        public bool Ativo { get; set; } = true; 
    }
}
