using Hospital.Models.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map;
public class PacienteMap
: IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Pacientes");
        builder.HasOne(x => x.Convenio)
            .WithMany(c => c.Pacientes)
            .HasForeignKey(x => x.ConvenioId);
    }
}
