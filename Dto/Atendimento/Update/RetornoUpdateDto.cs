using Hospital.Models.Atendimento;

namespace Hospital.Dto.Atendimento.Update;
public class RetornoUpdateDto
: AtendimentoUpdateDto
{
    public int ConsultaId { get; set; }
    public string Observacoes { get; set; }
}
