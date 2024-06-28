using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Application.Mappers;
public static class RetornoMapper
{
    public static Retorno ToDomain(
        this RetornoCreateDto dto, Medico medico)
    {
        return new Retorno(
            medico, dto.Inicio, dto.Fim);
    }
}