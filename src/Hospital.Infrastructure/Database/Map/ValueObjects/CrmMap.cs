using Hospital.Domain.Entities.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.ValueObjects;
public class CrmMap
: IEntityTypeConfiguration<Crm>
{
    public void Configure(EntityTypeBuilder<Crm> builder)
    {
        builder.HasIndex(x => new { x.Numero, x.Uf }).IsUnique();
    }
}