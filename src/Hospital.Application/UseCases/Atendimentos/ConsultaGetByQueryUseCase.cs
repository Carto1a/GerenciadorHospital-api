using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.Dto.Output.Atendimentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Repositories.Atendimentos;
using Hospital.Domain.Validators;

namespace Hospital.Application.UseCases.Atendimentos;
public class ConsultaGetByQueryUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    public ConsultaGetByQueryUseCase(
        IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task<IEnumerable<ConsultaOutputDto>> Handler(
        ConsultaGetByQueryDto request)
    {
        var validator = new DomainValidator("Não foi possível buscar consultas");
        validator.Query((int)request.Limit!, (int)request.Page!);

        if (request.Status != null)
            validator.isInEnum(
                request.Status,
                typeof(ConsultaStatus),
                "Status inválido");

        validator.Check();

        var consulta = await _consultaRepository
            .GetByQueryDtoAsync(request);
        return consulta;
    }
}