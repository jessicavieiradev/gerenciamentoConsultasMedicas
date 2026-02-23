namespace sistemaAgendamentoMedico.Entities
{
    public class Agenda
    {
        public long Id { get; set; }
        public long MedicoId { get; set; }
        public Medico Medico { get; set; }
        public string DiaSemana { get; set; }
        public string Mes { get; set; }
        public int Ano { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
    }
}
