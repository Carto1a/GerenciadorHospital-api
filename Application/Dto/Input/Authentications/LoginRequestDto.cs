using System.ComponentModel.DataAnnotations;

using Hospital.Application.Consts;

namespace Hospital.Application.Dto.Input.Authentications;
public class LoginRequestDto
{
    [Required]
    [EmailAddress(ErrorMessage = ValidationsConsts.EmailValidationError)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}