using Microsoft.AspNetCore.Identity;
using sistemaAgendamentoMedico.Entities;
using sistemaAgendamentoMedico.Enums;

namespace sistemaAgendamentoMedico.Data
{
    public static class SeedData
    {
        public static async Task ConfiguracoesIniciais(this IHost app) 
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            await CriarRolesPadrao(services);
            await CriarAdminPadrao(services);
        }
        public static  async Task CriarRolesPadrao(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<long>>>();

            string[] roles = {PerfilUsuario.Medico, PerfilUsuario.Paciente, PerfilUsuario.Admin };
            
            foreach (var roleName in roles)
            {
                if(!await roleManager.RoleExistsAsync(roleName))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole<long>(roleName));

                    if (!result.Succeeded)
                    {
                        var erro = string.Join(", ", result.Errors.Select(e => e.Description));
                        throw new Exception($"Erro ao criar role: {erro}");
                    }
                }
            }
        }

        private static async Task CriarAdminPadrao(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<Usuario>>();
            var context = services.GetRequiredService<AppDbContext>();
            var configuration = services.GetRequiredService<IConfiguration>();
            var senhaAdmin = configuration["SeedConfig:AdminPassword"];
            var emailAdmin = configuration["SeedConfig:AdminEmail"];

            if (string.IsNullOrEmpty(senhaAdmin))
                throw new Exception("Senha do Admin não configurada nos Segredos!");

            if (string.IsNullOrEmpty(emailAdmin))
                throw new Exception("Email do Admin não configurada nos Segredos!");

            var usuarioExistente = await userManager.FindByEmailAsync(emailAdmin);

            if (usuarioExistente == null)
            {
                var novoUsuario = new Usuario
                {
                    UserName = emailAdmin,
                    Email = emailAdmin,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(novoUsuario, senhaAdmin);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(novoUsuario, PerfilUsuario.Admin);

                    var perfilAdmin = new Admin
                    {
                        NomeCompleto = "Administrador Master",
                        EmailCorporativo = emailAdmin,
                        Departamento = "TI / Administração",
                        Ativo = true,
                        UsuarioId = novoUsuario.Id
                    };

                    context.Admin.Add(perfilAdmin);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
