using Hospital.Dto.Atendimento.Create;
using Hospital.Models.Agendamentos;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Atendimento;
public abstract class Atendimento
{
    public int ID { get; set; }
    public string MedicoId { get; set; }
    public string PacienteId { get; set; }
    public virtual Medico Medico { get; set; }
    public virtual Paciente Paciente { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public DateTime Criado { get; set; }
    public bool Convenio { get; set; }
    public decimal Custo { get; set; }

    public TimeSpan Duracao => Fim - Inicio;
    protected void Creation(
        AtendimentoCreationDto request,
        Medico medico,
        Paciente paciente)
    {
        Paciente = paciente;
        Medico = medico;
        Inicio = request.Inicio;
        Fim = request.Fim;
        Criado = DateTime.Now;
        Convenio = request.Convenio;
        Custo = request.Custo;
    }
}
