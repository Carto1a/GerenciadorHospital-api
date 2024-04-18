using Hospital.Models.Agendamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class ConsultaAgendamentoMap
: IEntityTypeConfiguration<ConsultaAgendamento>
{
    public void Configure(EntityTypeBuilder<ConsultaAgendamento> builder)
    {
        builder.HasOne(x => x.Tipo)
            .WithMany()
            .HasForeignKey(x => x.TipoId);
        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.AgendamentosConsultas)
            .HasForeignKey(x => x.PacienteId);
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.AgendamentosConsultas)
            .HasForeignKey(x => x.MedicoId);
    }
}
