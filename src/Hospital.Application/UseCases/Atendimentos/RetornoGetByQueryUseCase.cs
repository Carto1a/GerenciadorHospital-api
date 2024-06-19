using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.Dto.Output.Atendimentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Repositories.Atendimentos;
using Hospital.Domain.Validators;

namespace Hospital.Application.UseCases.Atendimentos;
public class RetornoGetByQueryUseCase
{
    private readonly IRetornoRepository _retornoRepository;
    public RetornoGetByQueryUseCase(
        IRetornoRepository retornoRepository)
    {
        _retornoRepository = retornoRepository;
    }

    public async Task<IEnumerable<RetornoOutputDto>> Handler(
        RetornoGetByQueryDto request)
    {
        var validator = new DomainValidator("Não foi possível buscar consultas");
        validator.Query((int)request.Limit!, (int)request.Page!);

        if (request.Status != null)
            validator.isInEnum(
                request.Status,
                typeof(ConsultaStatus),
                "Status inválido");

        validator.Check();

        var consulta = await _retornoRepository
            .GetByQueryDtoAsync(request);

        return consulta;
    }
}