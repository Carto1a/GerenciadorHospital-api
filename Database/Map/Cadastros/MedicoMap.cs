using Hospital.Models.Cadastro;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map.Cadastros;
public class MedicoMap
: IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.Property(x => x.CRMUF).HasMaxLength(2);

        builder.HasIndex(x => x.CRM).IsUnique();
        builder.HasIndex(x => x.DocCRMPath).IsUnique();

        builder.HasMany(x => x.Consultas)
            .WithOne(c => c.Medico)
            .HasForeignKey(x => x.MedicoId);

        builder.HasMany(x => x.Exames)
            .WithOne(e => e.Medico)
            .HasForeignKey(x => x.MedicoId);

        builder.HasMany(x => x.Retornos)
            .WithOne(r => r.Medico)
            .HasForeignKey(x => x.MedicoId);

        builder.HasMany(x => x.Laudos)
            .WithOne(l => l.Medico)
            .HasForeignKey(x => x.MedicoId);

        builder.HasMany(x => x.AgendamentosConsultas)
            .WithOne(a => a.Medico)
            .HasForeignKey(x => x.MedicoId);

        builder.HasMany(x => x.AgendamentosExames)
            .WithOne(a => a.Medico)
            .HasForeignKey(x => x.MedicoId);

        builder.HasMany(x => x.AgendamentosRetornos)
            .WithOne(a => a.Medico)
            .HasForeignKey(x => x.MedicoId);

        builder.HasIndex(x => x.DocCRMPath).IsUnique();
    }
}