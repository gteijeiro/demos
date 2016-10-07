using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoAgenda.Entities;
using DemoAgenda.Data;

namespace DemoAgenda.Logic
{
    public class AgendaLogic : IAgendaLogic
    {
        private IAgendaRepository _agendaRepository;

        #region Build

        public AgendaLogic()
        {
            _agendaRepository = new AgendaRepository();
        }

        #endregion

        #region Methods Publics

        public int Add(AgendaBE agenda)
        {
            agenda.LastChanged = DateTime.Now;
            return _agendaRepository.Add(agenda);
        }

        public void Delete(int id)
        {
            var agendaDelete = _agendaRepository.GetById(id);

            if(agendaDelete == null)
            {
                throw new Exception("No existe el contacto a eliminar.");
            }

            _agendaRepository.Delete(agendaDelete);
        }

        public AgendaBE GetById(int id)
        {
            return _agendaRepository.GetById(id);
        }

        public IEnumerable<AgendaBE> GetByUser(string user)
        {
            return _agendaRepository.GetAllByUser(user);
        }

        public AgendaBE Update(AgendaBE agenda)
        {
            agenda.LastChanged = DateTime.Now;
            return _agendaRepository.Update(agenda);
        }

        #endregion
    }
}
