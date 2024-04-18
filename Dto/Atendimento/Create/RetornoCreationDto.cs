
namespace Hospital.Dto.Atendimento.Create;
public class RetornoCreationDto : AtendimentoCreationDto
{
    public int ConsultaId { get; set; }
    public string Observacoes { get; set; }
}