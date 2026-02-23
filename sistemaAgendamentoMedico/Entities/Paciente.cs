namespace sistemaAgendamentoMedico.Entities
{
    public class Paciente
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
