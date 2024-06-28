/* using Hospital.Domain.Entities; */
/* using Microsoft.EntityFrameworkCore; */
/* using Microsoft.EntityFrameworkCore.Metadata.Builders; */

/* namespace Hospital.Infrastructure.Database.Map; */
/* public class ExameLaudoMap */
/* : IEntityTypeConfiguration<Exame_Laudo> */
/* { */
/*     public void Configure(EntityTypeBuilder<Exame_Laudo> builder) */
/*     { */
/*         /1* builder.HasKey(x => new { x.ExameId, x.LaudoId }); *1/ */

/*         builder.HasOne(x => x.Exame) */
/*             .WithMany(e => e.ExamesLaudos) */
/*             .HasForeignKey(x => x.ExameId) */
/*             .OnDelete(DeleteBehavior.ClientNoAction); */

/*         builder.HasOne(x => x.Laudo) */
/*             .WithMany(l => l.ExamesLaudos) */
/*             .HasForeignKey(x => x.LaudoId) */
/*             .OnDelete(DeleteBehavior.ClientNoAction); */
/*     } */
/* } */