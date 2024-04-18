using Hospital.Models.Atendimento;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class RetornoMap : IEntityTypeConfiguration<Retorno>
{
    public void Configure(EntityTypeBuilder<Retorno> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.Retornos)
            .HasForeignKey(x => x.MedicoId);
        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.Retornos)
            .HasForeignKey(x => x.PacienteId);
    }
}