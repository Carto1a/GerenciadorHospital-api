using Hospital.Database;
using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Input.Atendimentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Dtos.Output.Atendimentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;


namespace Hospital.Repository.Atendimentos;
public class ConsultaRepository
: AtendimentoRepository<
    Consulta,
    AtendimentoOutputDto,
    AtendimentoGetByQueryDto>,
IConsultaRepository
{
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public ConsultaRepository(
        AppDbContext context,
        UnitOfWork uow)
    : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public List<AgendamentoOutputDto> GetByQueryDto(AgendamentoGetByQueryDto query)
    {
        throw new NotImplementedException();
    }

    Task<AgendamentoOutputDto?> IAtendimentoRepository<Consulta, AgendamentoOutputDto, AgendamentoGetByQueryDto>.GetByIdDtoAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}