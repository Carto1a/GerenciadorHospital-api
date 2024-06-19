using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Domain.Entities;
public class Exame_Laudo
{
    public long Id { get; set; }
    public Guid? ExameId { get; set; }
    public Guid? LaudoId { get; set; }

    public virtual Exame? Exame { get; set; }
    public virtual Laudo? Laudo { get; set; }
}