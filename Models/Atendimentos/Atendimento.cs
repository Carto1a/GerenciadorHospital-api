using System.ComponentModel.DataAnnotations;

using Hospital.Dtos.Input.Atendimentos;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Atendimento;
public abstract class Atendimento
{
    [Key]
    public Guid Id { get; set; }
    public Guid? MedicoId { get; set; }
    public Guid? PacienteId { get; set; }
    public Guid? AgendamentoId { get; set; }
    public Guid? ConvenioId { get; set; }

    public virtual Medico? Medico { get; set; }
    public virtual Paciente? Paciente { get; set; }
    public virtual Convenio? Convenio { get; set; }

    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }

    public DateTime Criado { get; set; }

    public TimeSpan Duracao => Fim - Inicio;

    public Atendimento() { }
    public Atendimento(AtendimentoCreateDto request)
    {
        MedicoId = request.MedicoId;
        /* PacienteId = request.PacienteId; */
        AgendamentoId = request.AgendamentoId;
        /* ConvenioId = request.ConvenioId; */
        Inicio = request.Inicio;
        Fim = request.Fim;
        /* Custo = request.Custo; */
        /* CustoFinal = request.CustoFinal; */
        Criado = DateTime.Now;

        Validate();
    }

    // NOTE: para de usar o copilot para quase tudo
    public void Validate()
    {
        var validate = new Validators(
            $"Não foi possível validar o atendimento: {Id}");

        validate.MinValue(Custo, 0, "Custo");
        validate.MinValue(CustoFinal, 0, "Custo Final");
        /* validate.MaxDate(Inicio, DateTime.Now, "Inicio"); */
        /* validate.MinDate(Fim, Inicio, "Fim"); */

        validate.Check();
    }
}