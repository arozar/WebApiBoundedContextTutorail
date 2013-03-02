using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repairs.Domain
{
    public class Component
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
