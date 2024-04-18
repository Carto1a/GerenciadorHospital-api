using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Dto;
public class RegisterRequestDto
{
    [MinLength(Consts.UsernameMinLength, ErrorMessage = Consts.UsernameLengthValidationError)]
    public string? Username { get; set; }
    [Required]
    public string? Nome { get; set; }
    public string DataNascimento { get; set; }
    public bool Genero { get; set; }
    public string Telefone { get; set; }
    public int Cpf { get; set; }
    public int Cep { get; set; }
    public string NumeroCasa { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = Consts.EmailValidationError)]
    public string? Email { get; set; }
    [Required]
    [RegularExpression(Consts.PasswordRegex, ErrorMessage = Consts.PasswordValidationError)]
    public string? Password { get; set; }
}
