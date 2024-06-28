using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Mappers;
public static class ExameMapper
{
    public static Exame ToDomain(
        this ExameCreateDto dto, Medico medico)
    {
        return new Exame(
            medico, dto.Inicio, dto.Fim, dto.Resultado);
    }
}