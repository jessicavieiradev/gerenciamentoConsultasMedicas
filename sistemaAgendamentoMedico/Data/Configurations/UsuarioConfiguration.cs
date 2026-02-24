using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaAgendamentoMedico.Entities;

namespace sistemaAgendamentoMedico.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.Property(x => x.Ativo)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
