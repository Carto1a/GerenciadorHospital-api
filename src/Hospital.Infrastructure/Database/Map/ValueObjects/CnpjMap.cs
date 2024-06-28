using Hospital.Domain.Entities.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.ValueObjects;
public class CnpjMap
: IEntityTypeConfiguration<Cnpj>
{
    public void Configure(EntityTypeBuilder<Cnpj> builder)
    {
        builder.HasIndex(x => x.Numero).IsUnique();
    }
}