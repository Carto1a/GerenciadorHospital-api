using Hospital.Domain.Entities.Medicamentos;

namespace Hospital.Domain.Repositories;
public interface IMedicamentoLoteRepository
: IRepository<MedicamentoLote>
{
    Task<MedicamentoLote?> GetByCodigoAsync(string codigo);
    Task<MedicamentoLote?> GetByCodigoByMedicamentoIdAsync(string codigo, Guid medicamentoId);
}