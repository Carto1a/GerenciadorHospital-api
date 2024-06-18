using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.Dto.Output.Medicamentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Repositories;
using Hospital.Domain.Validators;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoLoteGetByQueryUseCase
{
    private readonly IMedicamentoLoteRepository _medicamentoLoteRepository;
    public MedicamentoLoteGetByQueryUseCase(
        IMedicamentoLoteRepository medicamentoLoteRepository)
    {
        _medicamentoLoteRepository = medicamentoLoteRepository;
    }

    public async Task<IEnumerable<MedicamentoLoteOutputDto>> Handler(
        MedicamentoLoteGetByQueryDto query)
    {
        var validator = new DomainValidator("Não foi possível buscar lotes de medicamento");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Status != null)
            validator.isInEnum(
                query.Status.Value,
                typeof(MedicamentoLoteStatus),
                "Status inválido");

        // NOTE: break code execution if validation fails
        validator.Check();

        var medicamentoLotes = await _medicamentoLoteRepository
            .GetByQueryDtoAsync(query);
        return medicamentoLotes;
    }
}