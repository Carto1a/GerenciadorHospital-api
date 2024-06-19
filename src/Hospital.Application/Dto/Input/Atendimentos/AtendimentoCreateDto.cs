namespace Hospital.Application.Dto.Input.Atendimentos;
public record AtendimentoCreateDto
{
    public Guid? MedicoId { get; set; }
    public Guid AgendamentoId { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}