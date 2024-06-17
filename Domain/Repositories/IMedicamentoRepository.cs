using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.Dto.Output.Medicamentos;
using Hospital.Domain.Entities.Medicamentos;

namespace Hospital.Domain.Repositories;
public interface IMedicamentoRepository
: IRepository<Medicamento, MedicamentoGetByQueryDto, MedicamentoOutputDto>
{
    Task<Guid> CreateAsync(Medicamento medicamento);
}