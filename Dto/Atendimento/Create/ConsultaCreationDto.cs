
namespace Hospital.Dto.Atendimento.Create;
public class ConsultaCreationDto : AtendimentoCreationDto
{
    public string Diagnostico { get; set; }
    public string? Observacoes { get; set; }
}
