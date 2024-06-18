using Hospital.Dtos.Input.Medicamentos;
using Hospital.Dtos.Output.Medicamentos;
using Hospital.Enums;
using Hospital.Infrastructure.Database.Repositories;
using Hospital.Repository.Medicamentos.Interfaces;

namespace Hospital.Application.UseCases.Medicamentos;
public class MedicamentoGetByQueryUseCase
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMedicamentoRepository _medicamentoRepository;
    public MedicamentoGetByQueryUseCase(
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