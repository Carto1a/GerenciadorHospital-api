using Hospital.Dto.Agendamento.Update;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Agendamentos;
public abstract class Agendamento<T>
{
    public int ID { get; set; }
    public int TipoId { get; set; }
    public string MedicoId { get; set; }
    public string PacienteId { get; set; }
    public virtual T? Tipo { get; set; }
    public virtual Medico Medico { get; set; }
    public virtual Paciente Paciente { get; set; }
    public DateTime DataHora { get; set; }
    public DateTime Criação { get; set; }
    public bool Cancelado { get; set; }
    public decimal Custo { get; set; }
    public bool Convenio { get; set; }
    public bool Deletado { get; set; }

    public void Link(T e) => Tipo = e;
    public void Cancelar() => Cancelado = true;
    public void Deletar() => Deletado = true;
    public void Update(AgendamentoUpdateDto novo)
    {
        DataHora = novo.DataHora;
        Custo = novo.Custo;
        Convenio = novo.Convenio;
    }
}
