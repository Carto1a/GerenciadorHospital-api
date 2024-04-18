using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto.Atividades;
public class RetornoCreationDto : GenericAtividadesCreationDto
{
    public TimeSpan Duracao { get; set; }
    public int ConsultaId { get; set; }
    public string Observacoes { get; set; }
    public decimal Custo { get; set; }
}
