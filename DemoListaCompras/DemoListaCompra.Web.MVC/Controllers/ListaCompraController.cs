using DemoListaCompra.Web.MVC.Models;
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
    }
}