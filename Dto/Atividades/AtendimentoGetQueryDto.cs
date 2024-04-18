
namespace Hospital.Dto.Atividades;
public class AtendimentoGetQueryDto
{
    public DateTime? MinDate { get; set; }
    public DateTime? MaxDate { get; set; }
    public int? MedicoId { get; set; }
    public int? PacienteId { get; set; }
    public int? Limit { get; set; }
    public int? Page { get; set; }
}
