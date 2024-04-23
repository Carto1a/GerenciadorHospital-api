using Hospital.Enums;

namespace Hospital.Dtos.Input.Agendamentos;
public record AgendamentoGetByQueryDto
: AGetByQuery
{
    public Guid? ConvencioId { get; set; }
    public DateTime? MinDataHora { get; set; }
    public DateTime? MaxDataHora { get; set; }
    public AgendamentoStatus? Status { get; set; }
}