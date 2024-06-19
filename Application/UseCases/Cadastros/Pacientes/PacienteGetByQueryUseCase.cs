using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Dto.Output.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Repositories.Cadastros;
using Hospital.Domain.Validators;

namespace Hospital.Application.UseCases.Cadastros.Pacientes;
public class PacienteGetByQueryUseCase
{
    private readonly IPacienteRepository _pacienteRepository;
    public PacienteGetByQueryUseCase(
        IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<IEnumerable<PacienteOutputDto>> Handler(
        PacienteGetByQueryDto query)
    {
        var validator = new DomainValidator("Não foi possível buscar pacientes");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Genero != null)
            validator.isInEnum(
                query.Genero,
                typeof(GeneroEnum),
                "Genero inválido");

        validator.Check();

        var pacientes = await _pacienteRepository
            .GetByQueryDtoAsync(query);

        return pacientes;
    }
}