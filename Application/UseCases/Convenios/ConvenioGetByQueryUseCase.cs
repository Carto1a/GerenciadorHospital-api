using Hospital.Dtos.Input.Convenios;
using Hospital.Dtos.Output.Convenios;
using Hospital.Repository;
using Hospital.Repository.Convenios.Ineterfaces;

namespace Hospital.Services.Convenios;
public class ConvenioGetByQueryService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IConvenioRepository _convenioRepository;
    public ConvenioGetByQueryService(
        UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<ConvenioOutputDto> Handler(
        ConvenioGetByQueryDto query)
    {
        var validator = new Validators("Não foi possível buscar convenios");
        // NOTE: colocar essas coisa no construtor da dto?
        validator.Query((int)query.Limit!, (int)query.Page!);
        if (query.CNPJ != null)
            validator.Cnpj(query.CNPJ, "CNPJ inválido");

        if (query.Nome != null)
        {
            validator.NotNullOrEmpty(query.Nome, "Nome inválido");
            validator.MinLength(query.Nome, 2, "Nome inválido");
        }

        // NOTE: break code execution if validation fails
        validator.Check();

        var convenios = _convenioRepository
            .GetConveniosGetByQueryDto(query);
        return convenios;
    }
}