using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public class Address
    {
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string PostCode { get; set; }
    }
}
