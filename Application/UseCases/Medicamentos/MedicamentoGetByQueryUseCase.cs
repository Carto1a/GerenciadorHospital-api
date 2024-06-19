using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.Dto.Output.Medicamentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Repositories;
using Hospital.Domain.Validators;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoGetByQueryUseCase
{
    private readonly IMedicamentoRepository _medicamentoRepository;
    public MedicamentoGetByQueryUseCase(
        IMedicamentoRepository medicamentoRepository)
    {
        _medicamentoRepository = medicamentoRepository;
    }

    public async Task<IEnumerable<MedicamentoOutputDto>> Handler(
        MedicamentoGetByQueryDto query)
    {
        var validator = new DomainValidator("Não foi possível buscar medicamentos");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Status != null)
            validator.isInEnum(
                query.Status.Value,
                typeof(MedicamentoStatus),
                "Status inválido");

        validator.Check();

        var medicamentoLotes = await _medicamentoRepository
            .GetByQueryDtoAsync(query);
        return medicamentoLotes;
    }
}