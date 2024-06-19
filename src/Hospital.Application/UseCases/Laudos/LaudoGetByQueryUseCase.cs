using Hospital.Application.Dto.Input.Laudos;
using Hospital.Application.Dto.Output;
using Hospital.Domain.Repositories;
using Hospital.Domain.Validators;

namespace Hospital.Application.UseCases.Laudos;
public class LaudoGetByQueryUseCase
{
    private readonly ILaudoRepository _repository;
    public LaudoGetByQueryUseCase(ILaudoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<LaudoOutputDto>> Handler(LaudoGetByQueryDto request)
    {
        var validator = new DomainValidator("Não foi possível buscar Laudos");
        validator.Query((int)request.Limit!, (int)request.Page!);
        validator.Check();

        var laudos = await _repository.GetByQueryDtoAsync(request);
        return laudos;
    }
}