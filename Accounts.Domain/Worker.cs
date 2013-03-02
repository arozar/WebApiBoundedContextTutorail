using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Repair> Tasks { get; set; }
    }
}
