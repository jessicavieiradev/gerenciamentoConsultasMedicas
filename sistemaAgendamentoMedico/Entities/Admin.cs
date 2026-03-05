namespace sistemaAgendamentoMedico.Entities
{
    public class Admin
    {
        public long Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string EmailCorporativo { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public bool Ativo { get; set; } = true;
    }
}
