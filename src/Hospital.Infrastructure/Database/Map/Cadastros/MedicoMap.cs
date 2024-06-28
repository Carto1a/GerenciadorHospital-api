using Hospital.Domain.Entities.Cadastros;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.Cadastros;
public class MedicoMap
: IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.OwnsOne(x => x.CRM);
        builder.HasIndex(x => x.DocCRMPath).IsUnique();

        builder.HasIndex(x => x.DocCRMPath).IsUnique();
    }
}