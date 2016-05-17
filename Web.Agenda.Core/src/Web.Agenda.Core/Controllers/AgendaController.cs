using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Web.Agenda.Core.Models;
using Web.Agenda.Core.ViewModels.Agenda;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace Web.Agenda.Core.Controllers
{
    [Authorize]
    public class AgendaController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public AgendaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Agenda
        public async Task<IActionResult> Index()
        {
            var agendaDb = await _context.Agendas.ToListAsync();
            var user = await this.GetCurrentUserAsync();
            var agendaViewModelList = agendaDb.Where(x => x.UserId == user.Id).Select(x => new AgendaViewModel()
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
                    LastName = agendaViewModel.LastName,
                    User = await this.GetCurrentUserAsync()                    
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

            AgendaDb agendaDb = await _context.Agendas.SingleAsync(m => m.Id == id);
            if (agendaDb == null)
            {
                return HttpNotFound();
            }

            var agendaViewModel = new AgendaViewModel()
            {
                Cell = agendaDb.Cell,
                FirstName = agendaDb.FirstName,
                Id = agendaDb.Id,
                LastName = agendaDb.LastName
            };

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

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _userManager.FindByIdAsync(HttpContext.User.GetUserId());
        }
    }
}
