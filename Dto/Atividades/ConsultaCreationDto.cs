
namespace Hospital.Dto.Atividades;
public class ConsultaCreationDto : GenericAtividadesCreationDto
{
    public string Diagnostico { get; set; }
    public string? Observacoes { get; set; }
}
