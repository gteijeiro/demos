using DemoAgenda.Entities;
using DemoAgenda.Logic;
using DemoAgenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAgenda.Controllers
{
    [RoutePrefix("api/agenda")]
    public class AgendaController : ApiController
    {
        private IAgendaLogic _agendaLogic;

        public AgendaController()
        {
            _agendaLogic = new AgendaLogic();
        }

        // GET: api/Agenda
        [HttpGet]
        public IHttpActionResult Get([FromUri]string user)
        {
            try
            {
                var agendas = _agendaLogic.GetByUser(user);

                var agendasViewModel = agendas.Select(x => new AgendaViewModel()
                {
                    firstname = x.Firtname,
                    id = x.Id,
                    lastname = x.Lastname,
                    number = x.Number,
                    user = x.User
                }).ToList();

                return Ok(agendasViewModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        [HttpGet]
        public IHttpActionResult GetById([FromUri]int id)
        {
            try
            {
                var agenda = _agendaLogic.GetById(id);

                var agendasViewModel = new AgendaViewModel()
                {
                    firstname = agenda.Firtname,
                    id = agenda.Id,
                    lastname = agenda.Lastname,
                    number = agenda.Number,
                    user = agenda.User
                };

                return Ok(agendasViewModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Agenda
        [HttpPost]
        public IHttpActionResult Post([FromBody]AgendaViewModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Fallo al agregar un contacto");
                }

                var agenda = new AgendaBE()
                {
                    Firtname = request.firstname,
                    Lastname = request.lastname,
                    Number = request.number,
                    User = request.user
                };

                request.id = _agendaLogic.Add(agenda);

                return Created(String.Format("api/agenda/{0}", request.id), request);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Agenda/5
        [HttpPut]
        public IHttpActionResult Put([FromBody]AgendaViewModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                   return BadRequest("Fallo al actualizar un contacto");
                }

                var agenda = new AgendaBE()
                {
                    Firtname = request.firstname,
                    Id = request.id,
                    Lastname = request.lastname,
                    Number = request.number,
                    User = request.user
                };

                var agendaUpdate = _agendaLogic.Update(agenda);

                var agendaVMUpdate = new AgendaViewModel()
                {
                    firstname = agendaUpdate.Firtname,
                    id = agendaUpdate.Id,
                    lastname = agendaUpdate.Lastname,
                    number = agendaUpdate.Number,
                    user = agendaUpdate.User
                };

                return Ok(agendaVMUpdate);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _agendaLogic.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
