namespace Hospital.Application.UseCases.Convenios;
public class ConvenioGetByIdUseCase
{
    private readonly UnitOfWork _uow;
    private readonly IConvenioRepository _convenioRepository;
    public ConvenioGetByIdUseCase(
        UnitOfWork uow)
    {
        _uow = uow;
    }

    public ConvenioOutputDto? Handler(Guid id)
    {
        var convenio = _convenioRepository
            .GetConvenioByIdDto(id);

        return convenio;
    }
}