using System.ComponentModel.DataAnnotations;

namespace DemoListaCompras.Models
{
    public class CompraModel
    {
        public int id { get; set; }
        public int amount { get; set; }
        [Required]
        public string description { get; set; }
        public decimal price { get; set; }
    }
}