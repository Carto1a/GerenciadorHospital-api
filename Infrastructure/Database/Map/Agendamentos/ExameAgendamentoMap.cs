using Hospital.Domain.Entities.Agendamentos;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.Agendamentos;
public class ExameAgendamentoMap
: IEntityTypeConfiguration<ExameAgendamento>
{
    public void Configure(EntityTypeBuilder<ExameAgendamento> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.AgendamentosExames)
            .HasForeignKey(x => x.MedicoId);

        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.AgendamentosExames)
            .HasForeignKey(x => x.PacienteId);

        builder.HasOne(x => x.Convenio)
            .WithMany(c => c.AgendamentosExames)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasOne(x => x.Consulta)
            .WithMany(c => c.AgendamentosExames)
            .HasForeignKey(x => x.ConsultaId);

        builder.HasIndex(x => x.Status);
    }
}