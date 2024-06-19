using Hospital.Domain.Entities.Medicamentos;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.Medicamentos;
public class MedicamentoMap
: IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder
            .HasMany(m => m.Pacientes)
            .WithMany(p => p.Medicamentos);

        builder
            .HasMany(m => m.MedicamentoLotes)
            .WithOne(ml => ml.Medicamento);
        builder
            .HasMany(m => m.Laudos)
            .WithMany(l => l.Medicamentos);

        builder.HasIndex(m => m.CodigoDeBarras).IsUnique();
        builder.HasIndex(m => m.Status);
    }
}