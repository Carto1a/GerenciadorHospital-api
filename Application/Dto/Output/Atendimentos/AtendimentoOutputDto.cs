namespace Hospital.Application.Dto.Output.Atendimentos;
public record AtendimentoOutputDto
{
    public Guid Id { get; init; }
    public Guid MedicoId { get; init; }
    public Guid PacienteId { get; init; }
    public Guid? AgendamentoId { get; init; }

    public DateTime Inicio { get; init; }
    public DateTime Fim { get; init; }
    public bool Convenio { get; init; }
    public decimal Custo { get; init; }
    public decimal CustoFinal { get; init; }

    public DateTime Criado { get; init; }

    public TimeSpan Duracao => Fim - Inicio;
}