using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sistemaAgendamentoMedico.Configurations;
using sistemaAgendamentoMedico.Data;
using sistemaAgendamentoMedico.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddSerigLogging();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<Usuario, IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.

await app.CriarRolesPadrao();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
