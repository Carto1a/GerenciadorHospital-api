using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.Dto.Output.Atendimentos;
using Hospital.Domain.Entities.Atendimentos;

namespace Hospital.Domain.Repositories.Atendimentos;
public interface IRetornoRepository
: IAtendimentoRepository<Retorno, RetornoGetByQueryDto, RetornoOutputDto>
{ }