using Hospital.Models.Agendamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class ExameAgendamentoMap
: IEntityTypeConfiguration<ExameAgendamento>
{
    public void Configure(EntityTypeBuilder<ExameAgendamento> builder)
    {
        builder.HasOne(x => x.Tipo)
            .WithMany()
            .HasForeignKey(x => x.TipoId);
        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.AgendamentosExames)
            .HasForeignKey(x => x.PacienteId);
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.AgendamentosExames)
            .HasForeignKey(x => x.MedicoId);
    }
}
