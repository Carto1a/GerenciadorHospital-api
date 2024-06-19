using Hospital.Application.Dto.Output.Convenios;
using Hospital.Domain.Repositories;

namespace Hospital.Application.UseCases.Convenios;
public class ConvenioGetByIdUseCase
{
    private readonly IConvenioRepository _convenioRepository;
    public ConvenioGetByIdUseCase(
        IConvenioRepository convenioRepository)
    {
        _convenioRepository = convenioRepository;
    }

    public async Task<ConvenioOutputDto?> Handler(Guid id)
    {
        var convenio = await _convenioRepository
            .GetByIdDtoAsync(id);

        return convenio;
    }
}