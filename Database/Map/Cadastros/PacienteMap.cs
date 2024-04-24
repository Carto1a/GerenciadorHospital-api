using Hospital.Models.Cadastro;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map.Cadastros;
public class PacienteMap
: IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        /* builder.ToTable("Pacientes"); */
        /* builder.HasIndex(x => x.CPF).IsUnique(); */

        builder.HasOne(x => x.Convenio)
            .WithMany(c => c.Pacientes)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasMany(x => x.Consultas)
            .WithOne(c => c.Paciente)
            .HasForeignKey(x => x.PacienteId);

        builder.HasMany(x => x.Exames)
            .WithOne(e => e.Paciente)
            .HasForeignKey(x => x.PacienteId);

        builder.HasMany(x => x.Retornos)
            .WithOne(r => r.Paciente)
            .HasForeignKey(x => x.PacienteId);

        builder.HasMany(x => x.Laudos)
            .WithOne(l => l.Paciente)
            .HasForeignKey(x => x.PacienteId);

        builder.HasMany(x => x.AgendamentosConsultas)
            .WithOne(a => a.Paciente)
            .HasForeignKey(x => x.PacienteId);

        builder.HasMany(x => x.AgendamentosExames)
            .WithOne(a => a.Paciente)
            .HasForeignKey(x => x.PacienteId);

        builder.HasMany(x => x.AgendamentosRetornos)
            .WithOne(a => a.Paciente)
            .HasForeignKey(x => x.PacienteId);

        builder.HasMany(x => x.Medicamentos)
            .WithMany(m => m.Pacientes);

        builder.HasIndex(x => x.DocIDPath).IsUnique();
        builder.HasIndex(x => x.DocConvenioPath).IsUnique();
    }
}