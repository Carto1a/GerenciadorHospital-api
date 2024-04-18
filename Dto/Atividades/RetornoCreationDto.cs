
namespace Hospital.Dto.Atividades;
public class RetornoCreationDto : GenericAtividadesCreationDto
{
    public int ConsultaId { get; set; }
    public string Observacoes { get; set; }
}
