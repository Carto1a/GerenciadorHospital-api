namespace Hospital.Dtos.Output.Atendimentos;
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

    public AtendimentoOutputDto(Guid id,
        Guid medicoId,
        Guid pacienteId,
        Guid? agendamentoId,
        DateTime inicio,
        DateTime fim,
        bool convenio,
        decimal custo,
        decimal custoFinal,
        DateTime criado)
    {
        Id = id;
        MedicoId = medicoId;
        PacienteId = pacienteId;
        AgendamentoId = agendamentoId;
        Inicio = inicio;
        Fim = fim;
        Convenio = convenio;
        Custo = custo;
        CustoFinal = custoFinal;
        Criado = criado;
    }
}