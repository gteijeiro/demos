using DemoListaCompras.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoListaCompras.Entities;
using DemoListaCompras.Data.Contracts;

namespace DemoListaCompras.Logic
{
    public class CompraLogic : ICompraLogic
    {
        #region Properties
        private ICompraData _compra;
        #endregion

        #region Build

        public CompraLogic(ICompraData compra)
        {
            _compra = compra;
        }

        #endregion

        #region Methods Public

        public CompraBE Add(CompraBE entity)
        {

            var descriptionExists = _compra.GetAll().SingleOrDefault(x => x.Decription.ToUpper().Trim().Equals(entity.Decription.Trim().ToUpper()));

            if (descriptionExists != null)
            {
                throw new Exception("Existe la compra.");
            }
            entity.DateChanged = DateTime.Now;
            entity.Id = _compra.Add(entity);

            return entity;
        }

        public void Delete(int id)
        {
            var compraExist = _compra.GetById(id);

            if(compraExist == null)
            {
                throw new Exception("La compra no existe");
            }

            _compra.Delete(compraExist);
        }

        public IEnumerable<CompraBE> GetAll()
        {
            return _compra.GetAll();
        }

        public CompraBE GetById(int id)
        {
            return _compra.GetById(id);
        }

        public CompraBE Update(CompraBE entity)
        {
            entity.DateChanged = DateTime.Now;
            return _compra.Update(entity);
        }

        #endregion

        #region Methods Private

        #endregion

    }
}
