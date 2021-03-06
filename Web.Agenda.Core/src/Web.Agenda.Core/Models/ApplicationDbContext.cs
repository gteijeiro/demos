﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Web.Agenda.Core.Models;
using Web.Agenda.Core.ViewModels.Agenda;

namespace Web.Agenda.Core.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<AgendaDb>().HasKey(c => c.User).

            base.OnModelCreating(builder);


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<AgendaDb> Agendas { get; set; }
    }
}
