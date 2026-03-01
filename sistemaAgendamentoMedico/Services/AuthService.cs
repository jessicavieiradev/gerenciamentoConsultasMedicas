using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sistemaAgendamentoMedico.Data;
using sistemaAgendamentoMedico.DTOs.Auth.Request;
using sistemaAgendamentoMedico.DTOs.Auth.Response;
using sistemaAgendamentoMedico.DTOs.Shared;
using sistemaAgendamentoMedico.Entities;
using sistemaAgendamentoMedico.Enums;
using sistemaAgendamentoMedico.Interfaces;

namespace sistemaAgendamentoMedico.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<Usuario> _userManager;
        private readonly AppDbContext _context;

        public AuthService(ITokenService tokenService, UserManager<Usuario> userManager, AppDbContext context)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<Result<AuthResponse>> RegistrarPaciente(RegistrarPacienteRequest request)
        {
            var usuarioExiste = await _context.Paciente.AnyAsync(p => p.Cpf == request.Cpf);
            if (usuarioExiste)
            {
                return Result<AuthResponse>.Falha("Paciente ja cadastrado");
            }
            var usuario = new Usuario
            {
                UserName = request.Cpf,
                Email = request.Email,
            };
            var novoUsuario = await _userManager.CreateAsync(usuario, request.Senha);
            if (!novoUsuario.Succeeded)
            {
                 var erros = novoUsuario.Errors.FirstOrDefault()?.Description ?? "Erro ao criar usuario";
                return Result<AuthResponse>.Falha(erros);
            }
            await _userManager.AddToRoleAsync(usuario, PerfilUsuario.Paciente);
                var novoPaciente = new Paciente
                {
                    UsuarioId = usuario.Id,
                    NomeCompleto = request.NomeCompleto,
                    Cpf = request.Cpf,
                    DataNascimento = request.DataNascimento,
                    Telefone = request.Telefone,
                    Ativo = true
                };

                
            try
            {
                _context.Paciente.Add(novoPaciente);
                await _context.SaveChangesAsync();
                return Result<AuthResponse>.Ok(new AuthResponse
                {
                    Token = await _tokenService.GerarToken(usuario, novoPaciente.NomeCompleto),
                    Nome = request.NomeCompleto,
                    Role = PerfilUsuario.Paciente
                });
            }
            catch (DbUpdateException dbEx)
            {
                // Isso vai te mostrar exatamente qual coluna está causando o erro
                var mensagem = dbEx.InnerException?.Message ?? dbEx.Message;
                return Result<AuthResponse>.Falha($"Erro de Banco: {mensagem}");
            }
            catch (Exception ex)
            {
                return Result<AuthResponse>.Falha($"Erro Geral: {ex.Message}");
            }
        }
        public async Task<Result<AuthResponse>> LoginPaciente(LoginRequest request)
        {
            var usuarioExiste = await _context.Paciente.FirstOrDefaultAsync(p => p.Cpf == request.Cpf);
            if(usuarioExiste == null)
            {
                return Result<AuthResponse>.Falha("Usuario ou senha invalidos.");
            }
            var usuario = await _userManager.FindByIdAsync(usuarioExiste.UsuarioId.ToString());

            if (usuario == null)
            {
                return Result<AuthResponse>.Falha("Usuario ou senha invalidos.");
            }

            var senhaValida = await _userManager.CheckPasswordAsync(usuario, request.Senha);

            if (!senhaValida)
            {
                return Result<AuthResponse>.Falha("Usuario ou senha invalidos.");
            }

            return Result<AuthResponse>.Ok(new AuthResponse
            {
                Token = await _tokenService.GerarToken(usuario, usuarioExiste.NomeCompleto),
                Nome = usuarioExiste.NomeCompleto,
                Role = PerfilUsuario.Paciente
            });
        }

    }
}
