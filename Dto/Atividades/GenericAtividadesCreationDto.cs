
namespace Hospital.Dto.Atividades;
public class GenericAtividadesCreationDto
{
    public int AgendamentoId { get; set; }
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }
    public bool Convenio { get; set; }
    public decimal Custo { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}
