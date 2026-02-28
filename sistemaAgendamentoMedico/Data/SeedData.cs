using Microsoft.AspNetCore.Identity;
using sistemaAgendamentoMedico.Enums;

namespace sistemaAgendamentoMedico.Data
{
    public static class SeedData
    {
        public static  async Task CriarRolesPadrao(this IHost app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

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
    }
}
