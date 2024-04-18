
namespace Hospital.Dto.Atividades;
public class ExameGetQueryDto
{
    public DateTime? minDate { get; set; }
    public DateTime? maxDate { get; set; }
    public int? medicoId { get; set; }
    public int? pacienteId { get; set; }
    public int? maxItens { get; set; }
    public int? page { get; set; }
}
