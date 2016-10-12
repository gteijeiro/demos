using DemoListaCompras.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListaCompras.Data.Contracts
{
    public interface ICompraData
    {
        CompraBE GetById(int id);
        IEnumerable<CompraBE> GetAll();
        int Add(CompraBE entity);
        CompraBE Update(CompraBE entity);
        void Delete(CompraBE entity);
    }
}
