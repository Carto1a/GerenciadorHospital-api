using Hospital.Application.Dto.Output.Atendimentos;
using Hospital.Domain.Repositories.Atendimentos;

namespace Hospital.Application.UseCases.Atendimentos;
public class RetornoGetByIdUseCase
{
    private readonly IRetornoRepository _retornoRepository;
    public RetornoGetByIdUseCase(
        IRetornoRepository retornoRepository)
    {
        _retornoRepository = retornoRepository;
    }

    public async Task<RetornoOutputDto?> Handler(Guid id)
    {
        var retorno = await _retornoRepository.GetByIdDtoAsync(id);
        return retorno;
    }
}