using DemoListaCompras.Data.Contracts;
using DemoListaCompras.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListaCompras.Data
{
    public class CompraContext : DbContext, ICompraContext
    {
        public DbSet<CompraBE> Compra { get; set; }

        void ICompraContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}
