using System.ComponentModel.DataAnnotations;

namespace Hospital.Dtos.Input.Authentications;
public class LoginRequestDto
{
    [Required]
    [EmailAddress(ErrorMessage = Consts.EmailValidationError)]
    public string Email { get; set; }
    [Required]
    [RegularExpression(Consts.PasswordRegex, ErrorMessage = Consts.PasswordValidationError)]
    public string Password { get; set; }
}