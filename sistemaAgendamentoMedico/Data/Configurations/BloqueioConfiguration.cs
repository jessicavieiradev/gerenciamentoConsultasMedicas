using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAgendamentoMedico.Entities;

namespace sistemaAgendamentoMedico.Data.Configurations
{
    public class BloqueioConfiguration : IEntityTypeConfiguration<Bloqueio>
    {
        public void Configure(EntityTypeBuilder<Bloqueio> builder)
        {
            builder.ToTable("bloqueios");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Motivo).HasMaxLength(200);

            builder.HasOne(x => x.Medico)
                   .WithMany()
                   .HasForeignKey(x => x.MedicoId);
        }
    }
}
