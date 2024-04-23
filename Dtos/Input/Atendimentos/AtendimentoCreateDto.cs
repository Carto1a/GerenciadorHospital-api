namespace Hospital.Dtos.Input.Atendimentos;
public record AtendimentoCreateDto
{
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid AgendamentoId { get; set; }
    public Guid? ConvenioId { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}