using Hospital.Enums;

namespace Hospital.Dtos.Input.Atendimentos;
public record ConsultaRetornoCreateDto : AtendimentoCreateDto
{
    public ConsultaStatus Status { get; set; }
    public Guid VeioDeRetornoId { get; set; }
}