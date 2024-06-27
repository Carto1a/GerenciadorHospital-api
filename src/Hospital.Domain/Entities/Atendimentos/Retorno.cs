using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;

namespace Hospital.Domain.Entities.Atendimentos;
public class Retorno : Atendimento
{
    public Consulta Consulta { get; set; }

    public RetornoStatus Status { get; set; }
    public Retorno() { }
    public Retorno(Medico medico,
        DateTime inicio, DateTime fim)
    : base(medico, inicio, fim)
    { }

    public void Realizar() => Status = RetornoStatus.Realizado;
    public void Terminar() => Status = RetornoStatus.Terminado;
}