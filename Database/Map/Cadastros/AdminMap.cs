using Hospital.Models.Cadastro;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map.Cadastros;
public class AdminMap : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        /* builder.ToTable("Admins"); */
        /* builder.HasOne(a => a.Cadastro) */
        /*     .WithOne(c => c.) */
        /*     .HasForeignKey<Admin>(a => a.CadastroId); */
    }
}