using Hospital.Models.Agendamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class RetornoAgendamentoMap
: IEntityTypeConfiguration<RetornoAgendamento>
{
    public void Configure(EntityTypeBuilder<RetornoAgendamento> builder)
    {
        builder.HasOne(x => x.Tipo)
            .WithMany()
            .HasForeignKey(x => x.TipoId);
        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.AgendamentosRetornos)
            .HasForeignKey(x => x.PacienteId);
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.AgendamentosRetornos)
            .HasForeignKey(x => x.MedicoId);
    }
}
