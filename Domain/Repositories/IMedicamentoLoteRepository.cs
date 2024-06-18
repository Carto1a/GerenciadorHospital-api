using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.Dto.Output.Medicamentos;
using Hospital.Domain.Entities.Medicamentos;

namespace Hospital.Domain.Repositories;
public interface IMedicamentoLoteRepository
: IRepository<MedicamentoLote, MedicamentoLoteGetByQueryDto, MedicamentoLoteOutputDto>
{
    Task<Guid> CreateAsync(MedicamentoLote medicoLote);
    Task<MedicamentoLote?> GetByCodigoAsync(string codigo);
    Task<MedicamentoLote?> GetByCodigoByMedicamentoIdAsync(string codigo, Guid medicamentoId);
    Task<MedicamentoLoteOutputDto?> GetByCodigoDtoAsync(string codigo);
}