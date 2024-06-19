using Hospital.Domain.Exceptions;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Atendimentos;

namespace Hospital.Application.UseCases.Atendimentos;
public class ExameCompletarUseCase
{
    private readonly IExameRepository _exameRepository;
    private readonly IUnitOfWork _uow;

    public ExameCompletarUseCase(
        IExameRepository exameRepository,
        IUnitOfWork uow)
    {
        _exameRepository = exameRepository;
        _uow = uow;
    }

    public async Task Handler(Guid id, string resultado)
    {
        var exame = await _exameRepository.GetByIdAsync(id);
        if (exame == null)
            throw new DomainException(
                $"Exame não encontrado: {id}",
                "Exame não encontrado");

        exame.Completar();
        exame.Resultado = resultado;

        // TODO: verificar se o ainda existe exame em processamento

        _exameRepository.UpdateAsync(exame);
        await _uow.SaveAsync();
    }
}