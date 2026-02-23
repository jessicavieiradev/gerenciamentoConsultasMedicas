namespace sistemaAgendamentoMedico.Entities
{
    public class Medico
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Crm { get; set; }
        public string Especialidade { get; set; }
        public bool Ativo { get; set; }
    }
}
