using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Company { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public ICollection<Repair> Repairs { get; set; }
    }
}
