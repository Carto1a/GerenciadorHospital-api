using Hospital.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Infrastructure.Database.Map;
public class ConvenioMap
: IEntityTypeConfiguration<Convenio>
{
    public void Configure(EntityTypeBuilder<Convenio> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.Ativo);
        builder.HasIndex(x => x.CNPJ);

        builder.HasMany(x => x.Pacientes)
            .WithOne(p => p.Convenio)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasMany(x => x.Consultas)
            .WithOne(c => c.Convenio)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasMany(x => x.Exames)
            .WithOne(e => e.Convenio)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasMany(x => x.Retornos)
            .WithOne(r => r.Convenio)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasMany(x => x.AgendamentosConsultas)
            .WithOne(a => a.Convenio)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasMany(x => x.AgendamentosExames)
            .WithOne(a => a.Convenio)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasMany(x => x.AgendamentosRetornos)
            .WithOne(a => a.Convenio)
            .HasForeignKey(x => x.ConvenioId);
    }
}