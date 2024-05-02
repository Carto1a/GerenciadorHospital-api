using Hospital.Dtos.Input.Medicamentos;
using Hospital.Dtos.Output.Medicamentos;
using Hospital.Repository;

namespace Hospital.Services.Medicamentos;
public class MedicamentoLoteGetByQueryService
{
    private readonly UnitOfWork _unitOfWork;
    public MedicamentoLoteGetByQueryService(
        UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<MedicamentoLoteOutputDto> Handler(
        MedicamentoLoteGetByQueryDto query)
    {
        var validator = new Validators("Não foi possível buscar lotes de medicamento");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Status != null)
            validator.isInEnum(query.Status.Value, "Status inválido");

        // NOTE: break code execution if validation fails
        validator.Check();

        var medicamentoLotes = _unitOfWork.MedicamentoLoteRepository
            .GetMedicamentoLotesByQueryDto(query);
        return medicamentoLotes;
    }
}