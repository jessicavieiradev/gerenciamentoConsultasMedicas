using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sistemaAgendamentoMedico.Entities;

namespace sistemaAgendamentoMedico.Data
{
    public sealed class AppDbContext : IdentityDbContext<Usuario, IdentityRole<long>, long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Bloqueio> Bloqueio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
