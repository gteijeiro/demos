using DemoListaCompras.Data.Contracts;
using DemoListaCompras.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListaCompras.Data
{
    public class CompraData : ICompraData
    {
        #region Properties 

        private ICompraContext _context;

        #endregion

        #region Build

        public CompraData(ICompraContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods Public

        public int Add(CompraBE entity)
        {
            try
            {
                var result = _context.Compra.Add(entity);
                _context.SaveChanges();
                return result.Id;
            }
            catch(Exception)
            {
                throw new Exception("Error al agregar una nueva compra.");
            }
        }

        public void Delete(CompraBE entity)
        {
            try
            {
                _context.Compra.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error al borrar una compra.");
            }
        }

        public IEnumerable<CompraBE> GetAll()
        {
            try
            {
                return _context.Compra;
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener todas las compras.");
            }
        }

        public CompraBE GetById(int id)
        {
            try
            {
                return _context.Compra.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener una compra.");
            }
        }

        public CompraBE Update(CompraBE entity)
        {
            try
            {
                var compraToUpdate = _context.Compra.SingleOrDefault(x => x.Id == entity.Id);
                compraToUpdate.Amount = entity.Amount;
                compraToUpdate.DateChanged = entity.DateChanged;
                compraToUpdate.Decription = entity.Decription;
                compraToUpdate.Price = entity.Price;
                _context.SaveChanges();

                return compraToUpdate;
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar una nueva compra.");
            }
        }

        #endregion

        #region Methods Private     

        #endregion
    }
}
