using Hospital.Dto.Atendimento.Create;
using Hospital.Dto.Atendimento.Update;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Service.Atendimentos.Interfaces;
public interface IConsultaService
: IAtendimentoService<
    Consulta,
    ConsultaAgendamento,
    ConsultaCreationDto,
    ConsultaUpdateDto>
{
}
