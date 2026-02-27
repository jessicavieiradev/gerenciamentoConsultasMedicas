namespace sistemaAgendamentoMedico.Entities
{
    public class Paciente
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateOnly DataNascimento { get; set; } 
        public string Telefone { get; set; } = string.Empty;    
        public bool Ativo { get; set; } = true;
    }
}
