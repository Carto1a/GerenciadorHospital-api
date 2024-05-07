using Hospital.Dtos.Input.Atendimentos;
using Hospital.Dtos.Output.Atendimentos;
using Hospital.Models.Atendimento;

namespace Hospital.Repository.Atendimentos.Interfaces;
public interface IConsultaRepository
: IAtendimentoRepository<
    Consulta,
    AtendimentoOutputDto,
    AtendimentoGetByQueryDto>
{ }