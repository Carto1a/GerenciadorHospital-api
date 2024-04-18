using Hospital.Models.Atendimento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class RetornoMap : IEntityTypeConfiguration<Retorno>
{
    public void Configure(EntityTypeBuilder<Retorno> builder)
    {
        builder.HasOne(x => x.Medico);
        builder.HasOne(x => x.Paciente);
    }
}
