using DemoListaCompras.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListaCompras.Data.Contracts
{
    public interface ICompraContext 
    {
        DbSet<CompraBE> Compra { get; set; }
        void SaveChanges();
    }
}
