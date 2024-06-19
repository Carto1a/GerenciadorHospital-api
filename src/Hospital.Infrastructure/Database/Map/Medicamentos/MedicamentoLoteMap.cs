using Hospital.Domain.Entities.Medicamentos;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.Medicamentos;
public class MedicamentoLoteMap
: IEntityTypeConfiguration<MedicamentoLote>
{
    public void Configure(EntityTypeBuilder<MedicamentoLote> builder)
    {
        builder.HasOne(m => m.Medicamento)
            .WithMany(m => m.MedicamentoLotes)
            .HasForeignKey(m => m.MedicamentoId);

        builder.HasIndex(m => m.Codigo).IsUnique();
        builder.HasIndex(m => m.Status);
    }
}