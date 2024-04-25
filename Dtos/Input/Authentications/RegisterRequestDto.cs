using System.ComponentModel.DataAnnotations;

using Hospital.Consts;
using Hospital.Enums;

namespace Hospital.Dtos.Input.Authentications;
public class RegisterRequestDto
{
    [Required]
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public GeneroEnum Genero { get; set; }
    public string? Telefone { get; set; }
    public int CPF { get; set; }
    public int CEP { get; set; }
    public string? NumeroCasa { get; set; }
    [Required]
    [EmailAddress(ErrorMessage =
        ValidationsConsts.EmailValidationError)]
    public string Email { get; set; }
    [Required]
    [RegularExpression(ValidationsConsts.PasswordRegex, ErrorMessage =
        ValidationsConsts.PasswordValidationError)]
    public string Password { get; set; }
}