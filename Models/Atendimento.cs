using Hospital.Database;
using Hospital.Dto.Atividades;
using Hospital.Models.Generics.Interfaces;
using Hospital.Repository.Interfaces;

namespace Hospital.Models;
public abstract class Atendimento
{
    public int ID { get; set; }
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public DateTime Criado { get; set; }
    public bool Convenio { get; set; }
    public decimal Custo { get; set; }

    public TimeSpan Duracao => Fim - Inicio;
    protected void Creation(
        GenericAtividadesCreationDto request,
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
