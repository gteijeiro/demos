using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAgenda.Models
{
    public class AgendaViewModel
    {
        public int id {get;set;}
        [Required]
        public string firstname {get;set;}
        [Required]
        public string lastname {get;set;}
        [Required]
        public string number {get;set;}
        [Required]
        public string user { get; set; }
    }
}