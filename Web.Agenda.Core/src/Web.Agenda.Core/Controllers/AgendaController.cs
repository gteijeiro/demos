using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Web.Agenda.Core.Models;
using Web.Agenda.Core.ViewModels.Agenda;
using Microsoft.AspNet.Authorization;

namespace Web.Agenda.Core.Controllers
{
    [Authorize]
    public class AgendaController : Controller
    {
        private ApplicationDbContext _context;

        public AgendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Agenda
        public async Task<IActionResult> Index()
        {
            var agendaDb = await _context.Agendas.ToListAsync();

            var agendaViewModelList = agendaDb.Select(x => new AgendaViewModel()
            {
                Cell = x.Cell,
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName
            }).ToList();

            return View(agendaViewModelList);
        }

        // GET: Agenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            AgendaDb agendaDb = await _context.Agendas.SingleAsync(m => m.Id == id);
            if (agendaDb == null)
            {
                return HttpNotFound();
            }

            var agendaViewModel = new AgendaViewModel()
            {
                LastName = agendaDb.LastName,
                Cell = agendaDb.Cell,
                FirstName = agendaDb.FirstName,
                Id = agendaDb.Id
            };

            return View(agendaViewModel);
        }

        // GET: Agenda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agenda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgendaViewModel agendaViewModel)
        {
            if (ModelState.IsValid)
            {
                var agendaDb = new AgendaDb()
                {
                    Cell = agendaViewModel.Cell,
                    FirstName = agendaViewModel.FirstName,
                    Id = agendaViewModel.Id,
                    LastName = agendaViewModel.LastName
                };

                _context.Agendas.Add(agendaDb);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(agendaViewModel);
        }

        // GET: Agenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            AgendaDb agendaDb = await _context.Agendas.SingleAsync(m => m.Id == id);
            if (agendaDb == null)
            {
                return HttpNotFound();
            }

            var agendaViewModel = new AgendaViewModel()
            {
                LastName = agendaDb.LastName,
                Cell = agendaDb.Cell,
                FirstName = agendaDb.FirstName,
                Id = agendaDb.Id
            };

            return View(agendaViewModel);
        }

        // POST: Agenda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AgendaViewModel agendaViewModel)
        {
            if (ModelState.IsValid)
            {
                var agenda = new AgendaDb()
                {
                    Cell = agendaViewModel.Cell,
                    FirstName = agendaViewModel.FirstName,
                    Id = agendaViewModel.Id,
                    LastName = agendaViewModel.LastName
                };
                _context.Update(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(agendaViewModel);
        }

        // GET: Agenda/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            AgendaDb agendaViewModel = await _context.Agendas.SingleAsync(m => m.Id == id);
            if (agendaViewModel == null)
            {
                return HttpNotFound();
            }

            return View(agendaViewModel);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AgendaDb agendaViewModel = await _context.Agendas.SingleAsync(m => m.Id == id);
            _context.Agendas.Remove(agendaViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
