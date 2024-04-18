using Hospital.Models.Atendimento;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map.Cadastros;
public class CadastroMap : IEntityTypeConfiguration<Consulta>
{
    public void Configure(EntityTypeBuilder<Consulta> builder)
    {
        /* builder.ToTable("Consultas"); */
        /* builder.HasOne(c => c.Medico) */
        /*     .WithMany(m => m.Consultas) */
        /*     .HasForeignKey(c => c.MedicoId); */
        /* builder.HasOne(c => c.Paciente) */
        /*     .WithMany(p => p.Consultas) */
        /*     .HasForeignKey(c => c.PacienteId); */
        /* builder.HasOne(c => c.Convenio) */
        /*     .WithMany(c => c.Consultas) */
        /*     .HasForeignKey(c => c.ConvenioId); */
    }
}