using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAgendamentoMedico.Entities;

namespace sistemaAgendamentoMedico.Data.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("paciente");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeCompleto).HasColumnName("nome_completo").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Cpf).HasMaxLength(11).IsRequired();
            builder.HasIndex(x => x.Cpf).IsUnique();

            builder.Property(x => x.DataNascimento).HasColumnType("date");
            builder.Property(x => x.Telefone).HasMaxLength(11);
        }
    }
}
