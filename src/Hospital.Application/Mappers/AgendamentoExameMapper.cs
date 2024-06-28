using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Mappers;
public static class AgendamentoExameMapper
{
    public static ExameAgendamento ToDomain(
        this AgendamentoExameCreateDto dto,
        Medico medico, Paciente paciente, Convenio? convenio, Consulta consulta)
    {
        return new ExameAgendamento(
            dto.DataHora, medico, paciente, convenio, dto.Custo,
            consulta);
    }
}