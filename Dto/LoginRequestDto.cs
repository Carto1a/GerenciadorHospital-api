using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto;
public class LoginRequestDto
{
    [Required]
    [EmailAddress(ErrorMessage = Consts.EmailValidationError)]
    public string? Email { get; set; }
    [Required]
    [RegularExpression(Consts.PasswordRegex, ErrorMessage = Consts.PasswordValidationError)]
    public string? Password { get; set; }

}
