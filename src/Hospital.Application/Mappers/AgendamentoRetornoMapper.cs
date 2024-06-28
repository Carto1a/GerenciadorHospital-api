using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Mappers;
public static class AgendamentoRetornoMapper
{
    public static RetornoAgendamento ToDomain(
        this AgendamentoRetornoCreateDto dto,
        Medico medico, Paciente paciente, Convenio? convenio, Consulta consulta)
    {
        return new RetornoAgendamento(
            dto.DataHora, medico, paciente, convenio, dto.Custo,
            consulta);
    }
}