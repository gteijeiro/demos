using DemoAgenda.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAgenda.Data
{
    public class AgendaContext : DbContext
    {
        public DbSet<AgendaBE> Agenda { get; set; }
    }
}
