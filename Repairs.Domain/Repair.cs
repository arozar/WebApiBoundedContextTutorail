using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repairs.Domain
{
    public class Repair
    {
        static decimal LabourCharge = 40M;

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Completed { get; set; }
        public ICollection<RepairPart> PartsUsed { get; set; }
        public int HoursOfLabour { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public decimal? TotalCost { get; set; }
        public ICollection<Worker> Team { get; set; }

        public void ProcessRepair()
        {
            if (this.Completed)
            {   //calculate total cost of components used
                decimal price = (PartsUsed != null)
                    ? PartsUsed.Select(p => p.Component.Price * p.Quantity).Sum()
                    : 0M;
                //if the repair took < 1hr cost is £10
                price += (HoursOfLabour > 0) ? HoursOfLabour * LabourCharge : 10;

                TotalCost = price;
            }

        }
    }
}
