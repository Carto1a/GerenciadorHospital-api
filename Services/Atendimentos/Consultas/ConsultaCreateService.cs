using Hospital.Dtos.Input.Atendimentos;
using Hospital.Repository;

namespace Hospital.Services.Atendimentos.Consultas;
public class ConsultaCreateService
{
    private readonly UnitOfWork _uow;
    public ConsultaCreateService(
        UnitOfWork uow)
    {
        _uow = uow;
    }

    public Guid Handler(
        ConsultaCreateDto consulta)
    {
        var repo = _uow.ConsultaRepository;

    }
}