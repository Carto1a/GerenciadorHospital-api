using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Mappers;
public static class ConsultaMapper
{
    public static Consulta ToDomain(
        this ConsultaCreateDto dto,
        Medico? medico)
    {
        return new Consulta(
            medico, dto.Inicio, dto.Fim, dto.Status, null);
    }
}