
using Hospital.Models.Cadastro;

namespace Hospital.Dto.Agendamento.Create;
public class AgendamentoCreateDto
{
    public DateTime DataHora { get; set; }
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid? ConvenioId { get; set; }
    public decimal Custo { get; set; }
}
