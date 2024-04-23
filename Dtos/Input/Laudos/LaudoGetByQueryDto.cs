namespace Hospital.Dtos.Input.Laudos;
public record LaudoGetByQueryDto
: AGetByQuery
{
    public Guid ExameId { get; set; }
    public Guid ConsultaId { get; set; }
}