using Hospital.Enums;

namespace Hospital.Dtos.Input.Atendimentos;
public record RetornoCreateDto
: AtendimentoCreateDto
{
    public Guid ConsultaId { get; set; }
    public Guid? NovaConsultaId { get; set; }

    public RetornoStatus Status { get; set; }
}