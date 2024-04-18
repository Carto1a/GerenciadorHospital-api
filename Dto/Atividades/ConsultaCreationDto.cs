using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto.Atividades;
public class ConsultaCreationDto : GenericAtividadesCreationDto
{
    public TimeSpan Duracao { get; set; }
    public string Diagnostico { get; set; }
    public string? Observacoes { get; set; }
    public decimal Custo { get; set; }
}
