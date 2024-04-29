using System.ComponentModel.DataAnnotations;

using Hospital.Consts;

namespace Hospital.Dtos.Input.Authentications;
public class LoginRequestDto
{
    [Required]
    [EmailAddress(ErrorMessage =
        ValidationsConsts.EmailValidationError)]
    public string Email { get; set; }
    [Required]
    [RegularExpression(ValidationsConsts.PasswordRegex, ErrorMessage =
        ValidationsConsts.PasswordValidationError)]
    public string Password { get; set; }
}