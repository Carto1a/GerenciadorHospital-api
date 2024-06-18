using Hospital.Dtos.Input.Medicamentos;
using Hospital.Dtos.Output.Medicamentos;
using Hospital.Enums;
using Hospital.Infrastructure.Database.Repositories;
using Hospital.Repository.MedicamentoLotes.Interfaces;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoLoteGetByQueryUseCase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMedicamentoLoteRepository _medicamentoLoteRepository;
    public MedicamentoLoteGetByQueryUseCase(
        UnitOfWork unitOfWork,
        IMedicamentoLoteRepository medicamentoLoteRepository)
    {
        _unitOfWork = unitOfWork;
        _medicamentoLoteRepository = medicamentoLoteRepository;
    }

    public List<MedicamentoLoteOutputDto> Handler(
        MedicamentoLoteGetByQueryDto query)
    {
        var validator = new Validators("Não foi possível buscar lotes de medicamento");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Status != null)
            validator.isInEnum(
                query.Status.Value,
                typeof(MedicamentoLoteStatus),
                "Status inválido");

        // NOTE: break code execution if validation fails
        validator.Check();

        var medicamentoLotes = _medicamentoLoteRepository
            .GetMedicamentoLotesByQueryDto(query);
        return medicamentoLotes;
    }
}