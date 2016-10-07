using DemoAgenda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAgenda.Logic
{
    public interface IAgendaLogic
    {
        int Add(AgendaBE agenda);
        AgendaBE Update(AgendaBE agenda);
        void Delete(int id);
        IEnumerable<AgendaBE> GetByUser(string user);
        AgendaBE GetById(int id);
    }
}
