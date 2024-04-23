using System.ComponentModel.DataAnnotations;
using Hospital.Enums;

namespace Hospital.Dtos.Output.Agendamentos;
public record AgendamentoOutputDto
{
    public Guid Id { get; init; }
    public Guid MedicoId { get; init; }
    public Guid PacienteId { get; init; }
    public Guid? ConvenioId { get; init; }

    [EnumDataType(typeof(AgendamentoStatus))]
    public AgendamentoStatus Status { get; init; }
    public decimal Custo { get; init; }
    public decimal CustoFinal { get; init; }

    public DateTime DataHora { get; init; }
    public DateTime Criado { get; init; }
    public bool Deletado { get; init; }

    public AgendamentoOutputDto(
        Guid id,
        Guid medicoId,
        Guid pacienteId,
        Guid? convenioId,
        AgendamentoStatus status,
        decimal custo,
        decimal custoFinal,
        DateTime dataHora,
        DateTime criado,
        bool deletado)
    {
        Id = id;
        MedicoId = medicoId;
        PacienteId = pacienteId;
        ConvenioId = convenioId;
        Status = status;
        Custo = custo;
        CustoFinal = custoFinal;
        DataHora = dataHora;
        Criado = criado;
        Deletado = deletado;
    }
}