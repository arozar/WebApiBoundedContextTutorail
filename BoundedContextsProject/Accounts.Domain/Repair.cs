using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public class Repair
    {
        static decimal LabourCharge = 40M;
     
        public int Id { get; set; }
        public bool Completed { get; set; }
        public int HoursOfLabour { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
