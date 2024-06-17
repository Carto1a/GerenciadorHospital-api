using Hospital.Dtos.Input.Atendimentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;

namespace Hospital.Application.UseCases.Atendimentos;
public class ConsultaGetByQueryUseCase
{
    private readonly IConsultaRepository _consultaRepository;
    public ConsultaGetByQueryUseCase(
        IConsultaRepository consultaRepository)
    {
        _consultaRepository = consultaRepository;
    }

    public IList<Consulta> Handler(
        AtendimentoGetByQueryDto request)
    {
        var validator = new Validators("Não foi possível buscar consultas");
        validator.Query((int)request.Limit!, (int)request.Page!);

        /* if (request.Status != null) */
        /*     validator.isInEnum( */
        /*         request.Status, */
        /*         typeof(ConsultaStatus), */
        /*         "Status inválido"); */

        validator.Check();

        var consulta = _consultaRepository
            .GetByQueryDtoAsync(request);
        return consulta;
    }
}