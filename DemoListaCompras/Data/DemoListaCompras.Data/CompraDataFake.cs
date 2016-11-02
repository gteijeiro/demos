using DemoListaCompras.Data.Contracts;
using DemoListaCompras.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListaCompras.Data
{
    public class CompraDataFake : ICompraData
    {
        #region Build

        public CompraDataFake()
        {
        }

        #endregion

        #region Methods Public

        public int Add(CompraBE entity)
        {
            try
            {
                return 0;
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar una nueva compra.");
            }
        }

        public void Delete(CompraBE entity)
        {
            try
            {

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
                return new List<CompraBE>()
                {
                    new CompraBE()
                    {
                        Amount = 00,
                        DateChanged = DateTime.Now,
                        Decription = "Other product 1",
                        Id = 1,
                        Price = 111
                    },
                    new CompraBE()
                    {
                        Amount = 01,
                        DateChanged = DateTime.Now,
                        Decription = "Other product 2",
                        Id = 2,
                        Price = 112
                    },
                    new CompraBE()
                    {
                        Amount = 03,
                        DateChanged = DateTime.Now,
                        Decription = "Other product 3",
                        Id = 3,
                        Price = 113
                    }
                };
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
                return new CompraBE()
                {
                    Amount = 00,
                    DateChanged = DateTime.Now,
                    Decription = "Other product 1",
                    Id = 1,
                    Price = 111
                };
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
                return new CompraBE()
                {
                    Amount = 00,
                    DateChanged = DateTime.Now,
                    Decription = "Other product 1",
                    Id = 1,
                    Price = 111
                };
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar una nueva compra.");
            }
        }

        #endregion

    }
}
