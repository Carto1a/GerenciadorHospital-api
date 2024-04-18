
namespace Hospital.Dto.Agendamento.Create;
public class AgendamentoCreateDto
{
    public DateTime DataHora { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
    public decimal Custo { get; set; }
    public bool Convenio { get; set; }
}
