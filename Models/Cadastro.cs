using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hospital.Models;
public class Cadastro : IdentityUser
{
    public string Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public bool Genero { get; set; }
    public string Telefone { get; set; }
    public int Cpf { get; set; }
    // tem que ser unico
    public int Cep { get; set; }
    public string NumeroCasa { get; set; }
    //ID
    //PasswordHash
    //Roles
    //Email
}
