namespace Hospital.Dtos.Input.Atendimentos;
public record AtendimentoCreateDto
{
    public Guid AgendamentoId { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}