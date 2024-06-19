using Hospital.Application.Dto.Input.Laudos;
using Hospital.Application.Dto.Output;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Repositories;
public interface ILaudoRepository
: IRepository<Laudo, LaudoGetByQueryDto, LaudoOutputDto>
{
    Task<Guid> CreateAsync(Laudo laudo);
}