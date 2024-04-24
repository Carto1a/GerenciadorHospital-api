using Hospital.Models.Atendimento;
using Hospital.Models.Cadastro;

namespace Hospital.Models;
public class Laudo
{
    public Guid Id { get; set; }
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid ExameId { get; set; }
    public Guid ConsultaId { get; set; }

    public virtual Medico? Medico { get; set; }
    public virtual Paciente? Paciente { get; set; }
    public virtual Exame? Exame { get; set; }
    public virtual Consulta? Consulta { get; set; }

    public string Descricao { get; set; }
    public Guid? DocPath { get; set; }

    public DateTime Criado { get; set; }
}