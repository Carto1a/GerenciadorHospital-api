namespace Hospital.Dtos.Input.Atendimentos;
public record AtendimentoGetByQueryDto
: AGetByQuery
{
    public Guid? ConvenioId { get; set; }
}