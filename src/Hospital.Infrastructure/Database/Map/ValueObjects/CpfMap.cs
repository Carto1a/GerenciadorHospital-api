using Hospital.Domain.Entities.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.ValueObjects;
public class CpfMap
: IEntityTypeConfiguration<Cpf>
{
    public void Configure(EntityTypeBuilder<Cpf> builder)
    {
        builder.HasIndex(x => x.Numero).IsUnique();
    }
}