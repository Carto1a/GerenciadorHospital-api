
namespace Hospital.Dto.Atendimento.Create;
public class AtendimentoCreationDto
{
    public Guid AgendamentoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid MedicoId { get; set; }
    public bool Convenio { get; set; }
    public decimal Custo { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}
