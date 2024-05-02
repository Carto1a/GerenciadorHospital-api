using Hospital.Dtos.Output.Medicamentos;
using Hospital.Models.Medicamentos;

namespace Hospital.Repository.MedicamentoLotes.Interfaces;
public interface IMedicamentoLoteRepository
{
    Guid CreateMedicamentoLote(MedicamentoLote medicamentoLote);
    MedicamentoLote? GetMedicamentoLoteById(Guid id);
    MedicamentoLote? GetMedicamentoLoteByCodigo(string codigo);
    MedicamentoLote? GetMedicamentoLoteByCodigoByMedicamentoId(string codigo, Guid medicamentoId);
    MedicamentoLoteOutputDto? GetMedicamentoLoteByIdDto(Guid id);
    MedicamentoLoteOutputDto? GetMedicamentoLoteByCodigoDto(string codigo);
    void UpdateMedicamentoLote(MedicamentoLote medicamentoLote);
}