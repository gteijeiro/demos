using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListaCompra.Web.MVC.Models
{
    public class CompraModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
