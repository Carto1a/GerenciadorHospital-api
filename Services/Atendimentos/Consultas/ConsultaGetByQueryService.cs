using Hospital.Dtos.Input.Atendimentos;
using Hospital.Dtos.Output.Atendimentos;
using Hospital.Repository;

namespace Hospital.Services.Atendimentos.Consultas;
public class ConsultaGetByQueryService
{
    private readonly UnitOfWork _unitOfWork;
    public ConsultaGetByQueryService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<AtendimentoOutputDto> Handler(
        AtendimentoGetByQueryDto query)
    {
        var validator = new Validators("Não foi possível buscar consultas");
        validator.Query((int)query.Limit!, (int)query.Page!);

        validator.Check();

        return _unitOfWork.ConsultaRepository
            .GetByQueryDto(query);
    }
}