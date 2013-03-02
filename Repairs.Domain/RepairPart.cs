using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repairs.Domain
{
    public class RepairPart
    {
        public int Quantity { get; set; }
        public int RepairId { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
    }
}
