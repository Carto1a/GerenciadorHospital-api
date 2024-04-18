using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Dto.Atividades;
public class ExameCreationDto : GenericAtividadesCreationDto
{
    public string Resultado { get; set; }
    public decimal Custo { get; set; }
}
