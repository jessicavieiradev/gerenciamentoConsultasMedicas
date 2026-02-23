using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAgendamentoMedico.Entities;

namespace sistemaAgendamentoMedico.Data.Configurations
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("agendamentos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Data).HasColumnType("date");
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne(x => x.Medico)
                   .WithMany()
                   .HasForeignKey(x => x.MedicoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Paciente)
                   .WithMany()
                   .HasForeignKey(x => x.PacienteId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
