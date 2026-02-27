namespace sistemaAgendamentoMedico.Entities
{
    public class Agenda
    {
        public long Id { get; set; }
        public long MedicoId { get; set; }
        public Medico Medico { get; set; } = new Medico();
        public string DiaSemana { get; set; } = string.Empty;
        public string Mes { get; set; } = string.Empty;
        public int Ano { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
    }
}
