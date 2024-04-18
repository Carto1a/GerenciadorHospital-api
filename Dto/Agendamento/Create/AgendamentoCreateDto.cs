
namespace Hospital.Dto.Agendamento.Create;
public class AgendamentoCreateDto
{
    public DateTime DataHora { get; set; }
    public string MedicoId { get; set; }
    public string PacienteId { get; set; }
    public decimal Custo { get; set; }
    public bool Convenio { get; set; }
}
