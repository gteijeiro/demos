using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Agenda.Core.ViewModels.Agenda
{
    public class AgendaViewModel
    {
        public int Id {get;set;}
        [Display(Name ="Nombre")]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Display(Name = "Telefono")]
        public string Cell { get; set; }
    }
}
