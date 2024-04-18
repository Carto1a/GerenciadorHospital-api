using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto;
public class RegisterRequestDto
{
    public string? Username { get; set; }
    [Required]
    public string? Nome { get; set; }
    // public DateOnly DataNascimento { get; set; }
    public bool Genero { get; set; }
    public string Telefone { get; set; }
    public int Cpf { get; set; }
    public int Cep { get; set; }
    public string NumeroCasa { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}
