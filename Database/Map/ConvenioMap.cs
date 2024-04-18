using Hospital.Models.Cadastro;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class ConvenioMap
: IEntityTypeConfiguration<Convenio>
{
    public void Configure(EntityTypeBuilder<Convenio> builder)
    {
        builder.HasMany(x => x.Pacientes)
            .WithOne(p => p.Convenio)
            .HasForeignKey(x => x.ConvenioId);
    }
}