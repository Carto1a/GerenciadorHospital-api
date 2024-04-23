namespace Hospital.Models.Atendimento;
public class Retorno
: Atendimento
{
    public Guid ConsultaId { get; set; }
    public Guid? NovaConsultaId { get; set; }

    public Consulta? Consulta { get; set; }
    public Consulta? NovaConsulta { get; set; }
}