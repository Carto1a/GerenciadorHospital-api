using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Mappers;
public static class AgendamentoConsultaMapper
{
    public static ConsultaAgendamento ToDomain(
        this AgendamentoConsultaCreateDto dto,
        Medico medico, Paciente paciente, Convenio? convenio)
    {
        return new ConsultaAgendamento(
            dto.DataHora, medico, paciente, convenio, dto.Custo);
    }
}