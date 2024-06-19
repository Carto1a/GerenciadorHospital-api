using System.ComponentModel.DataAnnotations;

using Hospital.Application.Consts;
using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Authentications;
public class RegisterRequestDto
{
    public required string Nome { get; set; }
    public required string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public GeneroEnum Genero { get; set; }
    public string? Telefone { get; set; }
    public required string CPF { get; set; }
    public required string CEP { get; set; }
    public required string NumeroCasa { get; set; }
    [Required]
    [EmailAddress(ErrorMessage =
        ValidationsConsts.EmailValidationError)]
    public required string Email { get; set; }
    [Required]
    [RegularExpression(ValidationsConsts.PasswordRegex, ErrorMessage =
        ValidationsConsts.PasswordValidationError)]
    public required string Password { get; set; }
}