using Hospital.Dtos.Input.Medicamentos;
using Hospital.Dtos.Output.Medicamentos;
using Hospital.Models.Medicamentos;

namespace Hospital.Repository.Medicamentos.Interfaces;
public interface IMedicamentoRepository
{
    Task<Guid> CreateMedicamentoAsync(Medicamento medicamento);
    Medicamento? GetMedicamentoById(Guid id);
    MedicamentoOutputDto? GetMedicamentoByIdDto(Guid id);
    List<MedicamentoOutputDto> GetMedicamentosByQueryDto(MedicamentoGetByQueryDto query);
    void UpdateMedicamento(Medicamento medicamento);
    void DesativarMedicamento(Guid id);
}