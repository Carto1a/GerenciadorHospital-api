using Hospital.Models.Cadastro;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map.Cadastros;
public class CadastroMap
: IEntityTypeConfiguration<Cadastro>
{
    public void Configure(EntityTypeBuilder<Cadastro> builder)
    {
        builder.UseTptMappingStrategy();
        builder.HasIndex(x => x.CPF).IsUnique();
    }
}