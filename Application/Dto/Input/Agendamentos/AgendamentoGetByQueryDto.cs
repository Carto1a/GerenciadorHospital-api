using Hospital.Domain.Enums;

namespace Hospital.Application.Dto.Input.Agendamentos;
public record AgendamentoGetByQueryDto : GetByQueryDto
{
    public Guid? MedicoId { get; set; }
    public Guid? PacienteId { get; set; }
    public Guid? ConvencioId { get; set; }
    public DateTime? MinDataHora { get; set; }
    public DateTime? MaxDataHora { get; set; }
    public AgendamentoStatus? Status { get; set; }
}