using DemoListaCompras.Entities;
using DemoListaCompras.Logic.Contracts;
using DemoListaCompras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemoListaCompras.Controller
{
    [RoutePrefix("api/compra")]
    public class CompraController : ApiController
    {
        private ICompraLogic _compra;

        public CompraController(ICompraLogic compra)
        {
            _compra = compra;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var getAll = _compra.GetAll().Select(x => new CompraModel()
                {
                    id = x.Id,
                    description = x.Decription,
                    amount = x.Amount,
                    price = x.Price
                }).ToList();

                return Ok(getAll);                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById([FromUri]int id)
        {
            try
            {
                var getById = _compra.GetById(id);

                CompraModel model = null;
                if (getById != null)
                {
                    model = new CompraModel()
                    {
                        id = getById.Id,
                        description = getById.Decription,
                        amount = getById.Amount,
                        price = getById.Price
                    };
                }


                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]CompraModel request)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest("Faltan campos obligatorios.");
                }

                var entity = new CompraBE()
                {
                    Decription = request.description,
                    Amount = request.amount,
                    Price = request.price
                };

                var addNewCompra = _compra.Add(entity);

                var model = new CompraModel()
                {
                    id = addNewCompra.Id,
                    description = addNewCompra.Decription,
                    amount = addNewCompra.Amount,
                    price = addNewCompra.Price
                };

                return Created(string.Format("api/compra/{0}", model.id),model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]CompraModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Faltan campos obligatorios.");
                }

                var entity = new CompraBE()
                {
                    Id = request.id,
                    Decription = request.description,
                    Amount = request.amount,
                    Price = request.price
                };

                var addUpdateCompra = _compra.Update(entity);

                var model = new CompraModel()
                {
                    id = addUpdateCompra.Id,
                    description = addUpdateCompra.Decription,
                    amount = addUpdateCompra.Amount,
                    price = addUpdateCompra.Price
                };

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                _compra.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
