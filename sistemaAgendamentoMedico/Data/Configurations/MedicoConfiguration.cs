using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAgendamentoMedico.Entities;

namespace sistemaAgendamentoMedico.Data.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("medico");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeCompleto).HasColumnName("nome_completo").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Crm).HasColumnName("crm").HasMaxLength(10).IsRequired();
            builder.HasIndex(x => x.Crm).IsUnique();

            builder.Property(x => x.Especialidade).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
        }
    }
}
