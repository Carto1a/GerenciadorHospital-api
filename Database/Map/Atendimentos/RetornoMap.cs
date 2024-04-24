using Hospital.Models.Atendimento;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.Database.Map.Atendimentos;
public class RetornoMap
: IEntityTypeConfiguration<Retorno>
{
    public void Configure(EntityTypeBuilder<Retorno> builder)
    {
        builder.HasOne(x => x.Medico)
            .WithMany(m => m.Retornos)
            .HasForeignKey(x => x.MedicoId);

        builder.HasOne(x => x.Paciente)
            .WithMany(p => p.Retornos)
            .HasForeignKey(x => x.PacienteId);

        // TODO: ver se ta errado
        builder.HasOne(x => x.Agendamento)
            .WithOne(a => a.Retorno)
            .HasForeignKey<Retorno>(x => x.AgendamentoId);

        builder.HasOne(x => x.Convenio)
            .WithMany(c => c.Retornos)
            .HasForeignKey(x => x.ConvenioId);

        builder.HasOne(x => x.Consulta)
            .WithOne(c => c.Retorno)
            .HasForeignKey<Retorno>(x => x.ConsultaId);

        builder.HasOne(x => x.NovaConsulta)
            .WithOne(c => c.VeioDeRetorno)
            .HasForeignKey<Retorno>(x => x.NovaConsultaId);

        builder.HasIndex(x => x.Status);
    }
}