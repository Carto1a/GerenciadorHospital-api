namespace Hospital.Application.Dto.Output;
public record LaudoOutputDto
{
    public Guid Id { get; init; }
    public Guid MedicoId { get; set; }
    public Guid? PacienteId { get; set; }
    public Guid ConsultaId { get; set; }
    public string Descricao { get; set; }
    public Guid? DocPath { get; set; }
    public DateTime Criado { get; set; }
    public bool Ativo { get; set; }
    public IEnumerable<Guid> ExamesIds { get; set; }
}