using DemoListaCompras.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListaCompras.Logic.Contracts
{
    public interface ICompraLogic
    {
        CompraBE GetById(int id);
        IEnumerable<CompraBE> GetAll();
        CompraBE Add(CompraBE entity);
        CompraBE Update(CompraBE entity);
        void Delete(int id);
    }
}
