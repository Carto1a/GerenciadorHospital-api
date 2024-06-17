using Hospital.Models.Atendimento;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map.Atendimentos;
public class ExameMap
: IEntityTypeConfiguration<Exame>
{
    public void Configure(EntityTypeBuilder<Exame> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.Exames)
            .HasForeignKey(x => x.MedicoId);

        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.Exames)
            .HasForeignKey(x => x.PacienteId);

        // TODO: ver se ta errado
        builder.HasOne(x => x.Agendamento)
            .WithOne(a => a.Exame)
            .HasForeignKey<Exame>(x => x.AgendamentoId);

        builder.HasOne(x => x.Convenio)
            .WithMany(c => c.Exames)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasOne(x => x.Consulta)
            .WithMany(c => c.Exames)
            .HasForeignKey(x => x.ConsultaId);

        builder.HasIndex(x => x.Status);
    }
}