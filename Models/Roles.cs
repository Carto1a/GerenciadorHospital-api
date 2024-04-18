using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hospital.Models;
public static class Roles 
{
    public const string Admin = "ADMIN";
    public const string Paciente = "PACIENTE";
    public const string Medico = "MEDICO";
}
