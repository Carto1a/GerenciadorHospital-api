using Hospital.Domain.Entities.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.ValueObjects;
public class EmailMap
: IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.HasIndex(x => x.Endereco).IsUnique();
    }
}