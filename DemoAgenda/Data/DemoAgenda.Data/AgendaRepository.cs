using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoAgenda.Entities;

namespace DemoAgenda.Data
{
    public class AgendaRepository : IAgendaRepository
    {
        private AgendaContext _agendaContext;

        #region Build

        public AgendaRepository()
        {
            _agendaContext = new AgendaContext();
        }
        #endregion

        #region Methods public
        public int Add(AgendaBE agenda)
        {
            try
            {
                var agendaToSave = _agendaContext.Agenda.Add(agenda);
                this.SaveChanges();

                return agendaToSave.Id;
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar un nuevo contacto.");
            }

        }

        public void Delete(AgendaBE agenda)
        {
            try
            {
                _agendaContext.Agenda.Remove(agenda);
                this.SaveChanges();
            }
            catch(Exception)
            {
                throw new Exception("Error al eliminar un nuevo.");
            }
        }

        public IEnumerable<AgendaBE> GetAllByUser(string user)
        {
            try
            {
                return _agendaContext.Agenda.Where(x => x.User.Equals(user));
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener los contactos.");
            }
        }

        public AgendaBE GetById(int id)
        {
            try
            {
                return _agendaContext.Agenda.SingleOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener un contacto.");
            }
        }

        public AgendaBE Update(AgendaBE agenda)
        {
            try
            {
                var agendaOld = _agendaContext.Agenda.SingleOrDefault(x => x.Id.Equals(agenda.Id));
                agendaOld.Lastname = agenda.Lastname;
                agendaOld.Firtname = agenda.Firtname;
                agendaOld.Number = agenda.Number;
                this.SaveChanges();

                return agendaOld;
            }
            catch (Exception)
            {
                throw new Exception("");
            }
        }

        #endregion

        #region Methods Privates

        private bool SaveChanges()
        {
            try
            {
                return (_agendaContext.SaveChanges()) > 0;
            }
            catch (Exception)
            {
                throw new Exception("Error al guardar los cambios.");
            }
        }

        #endregion

    }
}
