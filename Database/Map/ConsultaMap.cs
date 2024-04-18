using Hospital.Models.Atendimento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class ConsultaMap : IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.Consultas)
            .HasForeignKey(x => x.MedicoId);
        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.Consultas)
            .HasForeignKey(x => x.PacienteId);
    }
}
