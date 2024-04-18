using Hospital.Models.Atendimento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class ExameMap : IEntityTypeConfiguration<Exame>
{
    public void Configure(EntityTypeBuilder<Exame> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.Exames)
            .HasForeignKey(x => x.MedicoId);
        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.Exames)
            .HasForeignKey(x => x.PacienteId);
    }
}
