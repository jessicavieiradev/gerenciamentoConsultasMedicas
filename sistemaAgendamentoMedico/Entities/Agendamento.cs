using System.ComponentModel.DataAnnotations;

namespace sistemaAgendamentoMedico.Entities
{
    public class Agendamento
    {
        public long Id { get; set; }
        public long MedicoId { get; set; }
        public Medico Medico { get; set; } = null!;
        public long PacienteId { get; set; }
        public Paciente Paciente { get; set; } = null!;
        public DateOnly Data { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
        public int Status { get; set; }
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();   
    }
}
