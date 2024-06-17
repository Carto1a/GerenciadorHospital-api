using Hospital.Enums;

namespace Hospital.Application.Dto.Input.Atendimentos;
public record ConsultaRetornoCreateDto : AtendimentoCreateDto
{
    public ConsultaStatus Status { get; set; }
    public Guid VeioDeRetornoId { get; set; }
}