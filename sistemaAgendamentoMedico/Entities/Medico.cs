namespace sistemaAgendamentoMedico.Entities
{
    public class Medico
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Crm { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}
