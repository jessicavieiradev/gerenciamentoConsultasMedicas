namespace sistemaAgendamentoMedico.Entities
{
    public class Bloqueio
    {
        public long Id { get; set; }
        public long MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }
}
