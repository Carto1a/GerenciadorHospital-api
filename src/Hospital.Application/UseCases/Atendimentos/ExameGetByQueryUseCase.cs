using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.Dto.Output.Atendimentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Repositories.Atendimentos;
using Hospital.Domain.Validators;

namespace Hospital.Application.UseCases.Atendimentos;
public class ExameGetByQueryUseCase
{
    private readonly IExameRepository _exameRepository;
    public ExameGetByQueryUseCase(
        IExameRepository exameRepository)
    {
        _exameRepository = exameRepository;
    }

    public async Task<IEnumerable<ExameOutputDto>> Handler(ExameGetByQueryDto request)
    {
        var validator = new DomainValidator("Não foi possível buscar consultas");
        validator.Query((int)request.Limit!, (int)request.Page!);

        if (request.Status != null)
            validator.isInEnum(
                request.Status,
                typeof(ConsultaStatus),
                "Status inválido");

        validator.Check();

        var consulta = await _exameRepository
            .GetByQueryDtoAsync(request);
        return consulta;
    }
}