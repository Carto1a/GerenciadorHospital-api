using System.ComponentModel.DataAnnotations;

using Hospital.Dtos.Input.Atendimentos;
using Hospital.Enums;
using Hospital.Models.Agendamentos;

namespace Hospital.Models.Atendimento;
public class Retorno
: Atendimento
{
    public Guid ConsultaId { get; set; }

    public virtual RetornoAgendamento? Agendamento { get; set; }
    public virtual Consulta? Consulta { get; set; }

    [EnumDataType(typeof(RetornoStatus))]
    public RetornoStatus Status { get; set; }

    public Retorno()
    {
    }

    public Retorno(RetornoCreateDto dto)
    {
        AgendamentoId = dto.AgendamentoId;
        Inicio = dto.Inicio;
        Fim = dto.Fim;
        Criado = DateTime.Now;
        Status = dto.Status;
        ConsultaId = dto.ConsultaId;
    }

    public void Realizar() => Status = RetornoStatus.Realizado;
    public void Cancelar() => Status = RetornoStatus.Cancelado;
    public void Terminar() => Status = RetornoStatus.Terminado;
}