using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Database;
public class AppDbContext : IdentityDbContext<Cadastro>
{
    public DbSet<Cadastro> Cadastros { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Convenio> Convenios { get; set; }
    public DbSet<Retorno> Retornos { get; set; }
    public DbSet<Exame> Exames { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Models.Agendamentos.Consulta> AgendamentosConsultas { get; set; }
    public DbSet<Models.Agendamentos.Exame> AgendamentosExames { get; set; }
    public DbSet<Models.Agendamentos.Retorno> AgendamentosRetornos { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
}
