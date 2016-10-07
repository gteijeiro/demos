using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAgenda.Entities
{
    public class AgendaBE
    {
        [Key]
        public int Id { get; set; }
        public string Firtname { get; set; }
        public string Lastname { get; set; }
        public string Number { get; set; }
        public string User { get; set; }
        public DateTime LastChanged { get; set; }
    }
}
