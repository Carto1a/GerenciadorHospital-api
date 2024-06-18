using Hospital.Domain.Entities.Agendamentos;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.Agendamentos;
public class ConsultaAgendamentoMap
: IEntityTypeConfiguration<ConsultaAgendamento>
{
    public void Configure(EntityTypeBuilder<ConsultaAgendamento> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.AgendamentosConsultas)
            .HasForeignKey(x => x.MedicoId);

        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.AgendamentosConsultas)
            .HasForeignKey(x => x.PacienteId);

        builder.HasOne(x => x.Convenio)
            .WithMany(c => c.AgendamentosConsultas)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasIndex(x => x.Status);
    }
}