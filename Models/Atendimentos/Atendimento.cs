using System.ComponentModel.DataAnnotations;
using Hospital.Dto.Atendimento.Create;
using Hospital.Models.Atendimento.Interfaces;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Atendimento;
public abstract class Atendimento
: IAtendimento<AtendimentoCreationDto>
{
    [Key]
    public Guid Id { get; set; }
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public virtual Medico Medico { get; set; }
    public virtual Paciente Paciente { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public DateTime Criado { get; set; }
    public bool Convenio { get; set; }
    public decimal Custo { get; set; }

    public TimeSpan Duracao => Fim - Inicio;
    public void Creation(
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
