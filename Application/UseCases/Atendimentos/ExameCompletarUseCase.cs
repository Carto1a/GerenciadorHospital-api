using Hospital.Exceptions;
using Hospital.Repository;
using Hospital.Repository.Atendimentos.Interfaces;

namespace Hospital.Services.Atendimentos;
public class ExameCompletarService
{
    private readonly IExameRepository _exameRepository;
    private readonly UnitOfWork _uow;

    public ExameCompletarService(
        IExameRepository exameRepository,
        UnitOfWork uow)
    {
        _exameRepository = exameRepository;
        _uow = uow;
    }

    public async Task Handler(Guid id, string resultado)
    {
        var exame = await _exameRepository.GetByIdAsync(id);
        if (exame == null)
            throw new RequestError(
                $"Exame não encontrado: {id}",
                "Exame não encontrado");

        exame.Completar();
        exame.Resultado = resultado;

        // TODO: verificar se o ainda existe exame em processamento

        await _exameRepository.Update(exame);
    }
}