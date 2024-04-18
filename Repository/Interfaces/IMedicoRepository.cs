using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;

namespace Hospital.Repository.Interfaces;
public interface IMedicoRepository
{
    Medico? GetMedicoById(int id);
    List<Medico> GetMedicos(int limit, int page = 0); 
}
