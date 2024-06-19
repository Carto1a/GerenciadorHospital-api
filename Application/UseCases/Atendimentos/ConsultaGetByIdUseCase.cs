using Hospital.Application.Dto.Output.Atendimentos;
using Hospital.Domain.Repositories.Atendimentos;

namespace Hospital.Application.UseCases.Atendimentos;
public class ConsultaGetByIdUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    public ConsultaGetByIdUseCase(
        IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public async Task<ConsultaOutputDto?> Handler(Guid id)
    {
        var consulta = await _consultaRepository.GetByIdDtoAsync(id);
        return consulta;
    }
}