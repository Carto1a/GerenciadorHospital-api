using Hospital.Domain.Entities.Agendamentos;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.Agendamentos;
public class RetornoAgendamentoMap
: IEntityTypeConfiguration<RetornoAgendamento>
{
    public void Configure(EntityTypeBuilder<RetornoAgendamento> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.AgendamentosRetornos)
            .HasForeignKey(x => x.MedicoId);

        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.AgendamentosRetornos)
            .HasForeignKey(x => x.PacienteId);

        builder.HasOne(x => x.Convenio)
            .WithMany(c => c.AgendamentosRetornos)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasIndex(x => x.Status);
    }
}