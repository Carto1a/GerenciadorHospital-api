using Hospital.Database.Map;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Models.Cadastro;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Database;
public class AppDbContext
: IdentityDbContext<Cadastro, IdentityRole<Guid>, Guid>
{
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
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ConvenioMap());
        builder.ApplyConfiguration(new PacienteMap());
        builder.ApplyConfiguration(new ConsultaAgendamentoMap());
        builder.ApplyConfiguration(new ExameAgendamentoMap());
        builder.ApplyConfiguration(new RetornoAgendamentoMap());
        builder.ApplyConfiguration(new ConsultaMap());
        builder.ApplyConfiguration(new ExameMap());
        builder.ApplyConfiguration(new RetornoMap());
    }
}