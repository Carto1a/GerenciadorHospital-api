
namespace Hospital.Dto.Agendamento;
public class AgendamentoUpdateDto
{
    public DateTime DataHora { get; set; }
    public int MedicoId { get; set; } 
    public decimal Custo { get; set; }
    public bool Convenio { get; set; }
}
