using Hospital.Dtos.Input.Medicamentos;
using Hospital.Dtos.Output.Medicamentos;
using Hospital.Enums;
using Hospital.Repository;
using Hospital.Repository.Medicamentos.Interfaces;

namespace Hospital.Services.Medicamentos;
public class MedicamentoGetByQueryService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMedicamentoRepository _medicamentoRepository;
    public MedicamentoGetByQueryService(
        UnitOfWork unitOfWork,
        IMedicamentoRepository medicamentoRepository)
    {
        _unitOfWork = unitOfWork;
        _medicamentoRepository = medicamentoRepository;
    }

    public List<MedicamentoOutputDto> Handler(
        MedicamentoGetByQueryDto query)
    {
        var validator = new Validators("Não foi possível buscar medicamentos");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Status != null)
            validator.isInEnum(
                query.Status.Value,
                typeof(MedicamentoStatus),
                "Status inválido");

        // NOTE: break code execution if validation fails
        validator.Check();

        var medicamentoLotes = _medicamentoRepository
            .GetMedicamentosByQueryDto(query);
        return medicamentoLotes;
    }
}