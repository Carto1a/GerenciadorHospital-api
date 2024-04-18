using Hospital.Dto.Agendamento;

namespace Hospital.Models.Agendamentos;
public abstract class Agendamento<T>
{
    // public Agendamento()
    // {}
    public int ID { get; set; }
    public T? Tipo { get; set; }
    public DateTime DataHora { get; set; }
    public DateTime Criação { get; set; }
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public bool Cancelado { get; set; }
    public decimal Custo { get; set; }
    public bool Convenio { get; set; }
    public void Update(AgendamentoUpdateDto novo)
    {
        DataHora = novo.DataHora;
        Custo = novo.Custo;
        Convenio = novo.Convenio;
    }
}
