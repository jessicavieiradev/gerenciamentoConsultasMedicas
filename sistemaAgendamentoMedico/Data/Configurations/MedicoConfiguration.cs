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

            builder.Property(x => x.NomeCompleto)
                .HasColumnName("nome_completo")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Especialidade)
                .HasColumnName("especialidade")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Crm)
                .HasColumnName("crm")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.Uf)
                .HasColumnName("uf")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnName("cpf")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Ativo)
                .HasColumnName("ativo")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(x => x.Cpf).IsUnique();
            builder.HasIndex(x => new { x.Crm, x.Uf }).IsUnique();

            builder.HasOne(x => x.Usuario)
                .WithOne()
                .HasForeignKey<Medico>(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}