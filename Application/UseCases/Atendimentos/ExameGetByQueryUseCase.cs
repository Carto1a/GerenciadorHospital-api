using Hospital.Dtos.Input.Atendimentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;

namespace Hospital.Application.UseCases.Atendimentos;
public class ExameGetByQueryUseCase
{
    private readonly IExameRepository _exameRepository;
    public ExameGetByQueryUseCase(
        IExameRepository exameRepository)
    {
        _exameRepository = exameRepository;
    }

    public IList<Exame> Handler(
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

        var consulta = _exameRepository
            .GetByQueryDtoAsync(request);
        return consulta;
    }
}