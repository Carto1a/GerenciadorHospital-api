using System.ComponentModel.DataAnnotations;

namespace Hospital.Dtos.Input.Authentications;
public class RegisterRequestDto
{
    [Required]
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool Genero { get; set; }
    public string? Telefone { get; set; }
    public int CPF { get; set; }
    public int CEP { get; set; }
    public string? NumeroCasa { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = Consts.EmailValidationError)]
    public string Email { get; set; }
    [Required]
    [RegularExpression(Consts.PasswordRegex, ErrorMessage = Consts.PasswordValidationError)]
    public string Password { get; set; }
}