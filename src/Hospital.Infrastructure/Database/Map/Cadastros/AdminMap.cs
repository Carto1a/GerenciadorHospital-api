using Hospital.Domain.Entities.Cadastros;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.Cadastros;
public class AdminMap
: IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        /* builder.ToTable("Admins"); */
    }
}