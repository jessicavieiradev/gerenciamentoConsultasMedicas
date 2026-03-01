using System.ComponentModel.DataAnnotations;

namespace sistemaAgendamentoMedico.DTOs.Auth.Request
{
    public class RegistrarPacienteRequest
    {

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O nome deve ter no minimo 3 caracteres.")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateOnly DataNascimento { get; set; }

        [StringLength(11, ErrorMessage = "O telefone não pode exceder 11 dígitos.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;
    }
}
