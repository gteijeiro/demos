using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoListaCompras.Entities
{
    public class CompraBE
    {
        [Key]
        public int Id {get;set;}
        public string Decription {get;set;}
        public DateTime DateChanged {get;set;}
        public int Amount {get;set;}
        public decimal Price {get;set;}
    }
}
