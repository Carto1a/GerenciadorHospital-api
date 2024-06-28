/* using Hospital.Domain.Entities; */

/* using Microsoft.EntityFrameworkCore; */
/* using Microsoft.EntityFrameworkCore.Metadata.Builders; */

/* namespace Hospital.Infrastructure.Database.Map; */
/* public class LaudoMap */
/* : IEntityTypeConfiguration<Laudo> */
/* { */
/*     public void Configure(EntityTypeBuilder<Laudo> builder) */
/*     { */
/*         builder.HasOne(x => x.Medico) */
/*             .WithMany(m => m.Laudos) */
/*             .HasForeignKey(x => x.MedicoId); */

/*         builder.HasOne(x => x.Paciente) */
/*             .WithMany(p => p.Laudos) */
/*             .HasForeignKey(x => x.PacienteId); */

/*         /1* builder.HasMany(x => x.Exames) *1/ */
/*         /1*     .WithMany(e => e.Laudos); *1/ */

/*         builder.HasOne(x => x.Consulta) */
/*             .WithMany(c => c.Laudos) */
/*             .HasForeignKey(x => x.ConsultaId); */

/*         builder.HasMany(x => x.Medicamentos) */
/*             .WithMany(m => m.Laudos); */

/*         builder.HasIndex(x => x.DocPath).IsUnique(); */
/*     } */
/* } */