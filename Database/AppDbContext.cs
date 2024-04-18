using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.Models.Agendamentos;
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
    public DbSet<ConsultaAgendamento> AgendamentosConsultas { get; set; }
    public DbSet<ExameAgendamento> AgendamentosExames { get; set; }
    public DbSet<RetornoAgendamento> AgendamentosRetornos { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Cadastro>()
            .HasIndex(u => u.Cpf)
            .IsUnique();
        builder.Entity<Cadastro>()
            .HasIndex(u => u.Cpf)
            .IsUnique();
    }
}
