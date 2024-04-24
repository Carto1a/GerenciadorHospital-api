using Hospital.Models.Atendimento;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map.Atendimentos;
public class ConsultaMap
: IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.Consultas)
            .HasForeignKey(x => x.MedicoId);

        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.Consultas)
            .HasForeignKey(x => x.PacienteId);

        // TODO: ver se ta errado
        builder.HasOne(x => x.Agendamento)
            .WithOne(a => a.Consulta)
            .HasForeignKey<Consulta>(x => x.AgendamentoId);

        builder.HasOne(x => x.Convenio)
            .WithMany(c => c.Consultas)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasMany(x => x.Exames)
            .WithOne(e => e.Consulta)
            .HasForeignKey(e => e.ConsultaId);

        builder.HasMany(x => x.Laudos)
            .WithOne(l => l.Consulta)
            .HasForeignKey(l => l.ConsultaId);

        builder.HasIndex(x => x.Status);
    }
}