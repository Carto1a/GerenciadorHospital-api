using Hospital.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class LaudoMap
: IEntityTypeConfiguration<Laudo>
{
    public void Configure(EntityTypeBuilder<Laudo> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.Laudos)
            .HasForeignKey(x => x.MedicoId);

        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.Laudos)
            .HasForeignKey(x => x.PacienteId);

        builder.HasOne(x => x.Exame)
            .WithOne(e => e.Laudo)
            .HasForeignKey<Laudo>(x => x.ExameId);

        builder.HasOne(x => x.Consulta)
            .WithMany(c => c.Laudos)
            .HasForeignKey(x => x.ConsultaId);

        builder.HasMany(x => x.Medicamentos)
            .WithMany(m => m.Laudos);

        builder.HasIndex(x => x.DocPath).IsUnique();
    }
}