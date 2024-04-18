namespace Hospital.Dto.Atendimento.Update;
public class ConsultaUpdateDto : AtendimentoUpdateDto
{
    public string Diagnostico { get; set; }
    public string? Observacoes { get; set; }
}