using DemoAgenda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAgenda.Data
{
    public interface IAgendaRepository
    {
        int Add(AgendaBE agenda);
        AgendaBE Update(AgendaBE agenda);
        void Delete(AgendaBE agenda);
        AgendaBE GetById(int id);
        IEnumerable<AgendaBE> GetAllByUser(string user);
    }
}
