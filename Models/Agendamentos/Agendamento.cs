using System.ComponentModel.DataAnnotations;
using Hospital.Dto.Agendamento.Update;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Agendamentos;
public abstract class Agendamento<T>
{
    [Key]
    public Guid Id { get; set; }
    public Guid? TipoId { get; set; }
    public Guid MedicoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid? ConvenioId { get; set; }
    public virtual T? Tipo { get; set; }
    public virtual Medico Medico { get; set; }
    public virtual Paciente Paciente { get; set; }
    public virtual Convenio? Convenio { get; set; }
    [EnumDataType(typeof(AgendamentoStatus))]
    public AgendamentoStatus Status { get; set; }
    public DateTime DataHora { get; set; }
    public DateTime Criação { get; set; }
    public decimal Custo { get; set; }
    public decimal CustoFinal { get; set; }
    public bool Deletado { get; set; }

    public void Link(T e) => Tipo = e;
    public void Cancelar() => Status = AgendamentoStatus.Cancelado;
    public void Realizar() => Status = AgendamentoStatus.Realizado;
    public void EmEspera() => Status = AgendamentoStatus.EmEspera;
    public void EmAndamento() => Status = AgendamentoStatus.EmAndamento;
    public void Deletar()
    {
        Deletado = true;
        Status = AgendamentoStatus.Cancelado;
    }
    public void Update(AgendamentoUpdateDto request)
    {
        DataHora = request.DataHora;
        Custo = request.Custo;
    }
}
