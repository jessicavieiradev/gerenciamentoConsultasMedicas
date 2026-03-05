using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAgendamentoMedico.Entities;

namespace sistemaAgendamentoMedico.Data.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("admin");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NomeCompleto).HasMaxLength(200).IsRequired();
            builder.Property(x => x.EmailCorporativo).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Departamento).HasMaxLength(100);
            builder.HasOne(x => x.Usuario)
                .WithOne()
                .HasForeignKey<Admin>(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
