using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Repository.Atendimentos.Interfaces;
public interface IExameRepository
: IAtendimentoRepository<
    Exame,
    AgendamentoOutputDto,
    AgendamentoGetByQueryDto>
{ }