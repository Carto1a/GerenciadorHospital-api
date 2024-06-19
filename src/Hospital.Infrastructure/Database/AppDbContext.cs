using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Entities.Medicamentos;
using Hospital.Infrastructure.Database.Map;
using Hospital.Infrastructure.Database.Map.Agendamentos;
using Hospital.Infrastructure.Database.Map.Atendimentos;
using Hospital.Infrastructure.Database.Map.Cadastros;
using Hospital.Infrastructure.Database.Map.Medicamentos;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database;
#pragma warning disable CS8618
public class AppDbContext
: IdentityDbContext<Cadastro, IdentityRole<Guid>, Guid>
{
    // Agendamentos
    public DbSet<ConsultaAgendamento> AgendamentosConsultas { get; set; }
    public DbSet<ExameAgendamento> AgendamentosExames { get; set; }
    public DbSet<RetornoAgendamento> AgendamentosRetornos { get; set; }

    // Atendimentos
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Exame> Exames { get; set; }
    public DbSet<Retorno> Retornos { get; set; }

    // Cadastro
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Admin> Admins { get; set; }

    // Medicamento
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<MedicamentoLote> MedicamentoLotes { get; set; }

    // Outros
    public DbSet<Convenio> Convenios { get; set; }
    public DbSet<Laudo> Laudos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // TODO: many to many exames laudos

        builder.ApplyConfiguration(new ConsultaAgendamentoMap());
        builder.ApplyConfiguration(new ExameAgendamentoMap());
        builder.ApplyConfiguration(new RetornoAgendamentoMap());

        builder.ApplyConfiguration(new ConsultaMap());
        builder.ApplyConfiguration(new ExameMap());
        builder.ApplyConfiguration(new RetornoMap());

        builder.ApplyConfiguration(new MedicamentoMap());
        builder.ApplyConfiguration(new MedicamentoLoteMap());

        builder.ApplyConfiguration(new CadastroMap());
        builder.ApplyConfiguration(new PacienteMap());
        builder.ApplyConfiguration(new MedicoMap());
        builder.ApplyConfiguration(new AdminMap());

        builder.ApplyConfiguration(new ConvenioMap());
        builder.ApplyConfiguration(new LaudoMap());
    }
}