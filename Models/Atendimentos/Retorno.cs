using Hospital.Dto.Atendimento.Create;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento.Interfaces;
using Hospital.Models.Cadastro;

namespace Hospital.Models.Atendimento;
public class Retorno
: Atendimento,
IAtendimento<RetornoCreationDto>
{
    public virtual RetornoAgendamento Agendamento { get; set; }
    public Consulta Consulta { get; set; }
    public string Observacoes { get; set; }
    public void Creation(
        RetornoCreationDto request,
        Medico medico,
        Paciente paciente)
    {
        base.Creation(request, medico, paciente);
        Observacoes = request.Observacoes;
    }
}
