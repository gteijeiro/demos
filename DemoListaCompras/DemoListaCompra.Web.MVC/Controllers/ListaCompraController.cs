using DemoListaCompra.Web.MVC.Models;
using DemoListaCompras.Entities;
using DemoListaCompras.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoListaCompra.Web.MVC.Controllers
{
    public class ListaCompraController : Controller
    {
        private ICompraLogic compraLogic;

        public ListaCompraController(ICompraLogic compraLogic)
        {
            this.compraLogic = compraLogic;
        }


        // GET: ListaCompra
        public ActionResult Index()
        {
            var allcompraList = compraLogic.GetAll().Select(x => new CompraModel()
            {
                Amount = x.Amount,
                Description = x.Decription,
                Id = x.Id,
                Price = x.Price
            }).ToList();

            return View(allcompraList);
        }

        public ActionResult Edit(int id)
        {
            var edit = compraLogic.GetById(id);

            var model = new CompraModel()
            {
                Amount = edit.Amount,
                Description = edit.Decription,
                Id = edit.Id,
                Price = edit.Price
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CompraModel model)
        {
            if(ModelState.IsValid)
            {
                var compra = new CompraBE()
                {
                    Amount = model.Amount,
                    DateChanged = DateTime.Now,
                    Decription = model.Description,
                    Id = model.Id,
                    Price = model.Price
                };

                compraLogic.Update(compra);

               return RedirectToAction("Index");
            }            

            return View(model);
        }

    }
}