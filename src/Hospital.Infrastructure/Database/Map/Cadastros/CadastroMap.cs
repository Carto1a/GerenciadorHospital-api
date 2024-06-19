using Hospital.Domain.Entities.Cadastros;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map.Cadastros;
public class CadastroMap
: IEntityTypeConfiguration<Cadastro>
{
    public void Configure(EntityTypeBuilder<Cadastro> builder)
    {
        builder.UseTptMappingStrategy();
        builder.Property(x => x.CPF).HasMaxLength(11);

        builder.HasIndex(x => x.CPF).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.Ativo);
        builder.HasIndex(x => x.Genero);
    }
}