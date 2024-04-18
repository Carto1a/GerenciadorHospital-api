using Hospital.Models.Atendimento;

namespace Hospital.Dto.Atendimento.Update;
public class RetornoUpdateDto : AtendimentoUpdateDto
{
    public Consulta Consulta { get; set; }
    public string Observacoes { get; set; }
}
