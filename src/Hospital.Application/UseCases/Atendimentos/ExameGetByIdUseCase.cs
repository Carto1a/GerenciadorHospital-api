using Hospital.Application.Dto.Output.Atendimentos;
using Hospital.Domain.Repositories.Atendimentos;

namespace Hospital.Application.UseCases.Atendimentos;
public class ExameGetByIdUseCase
{
    private readonly IExameRepository _exameRepository;
    public ExameGetByIdUseCase(
        IExameRepository exameRepository)
    {
        _exameRepository = exameRepository;
    }

    public async Task<ExameOutputDto?> Handler(Guid id)
    {
        var exame = await _exameRepository.GetByIdDtoAsync(id);
        return exame;
    }
}