using Repairs.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Accounts.Context;
using Accounts.Domain;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new RepairsContext())
            {   //retrieve entire object graph
                var RepairsQuery = db.Repairs
                    .Include(r => r.Account)
                    .Include(r => r.Team)
                    .Include(r => r.PartsUsed.Select(pu => pu.Component));
            }

            using (var db = new AccountsContext())
            {
                var WorkerQuery = db.Workers.Include(w => w.Tasks).ToList();
                var ComponentQuery = db.Components.Include(c => c.Usage.Select(r=>r.Repair)).ToList();
                var AccountQuery = db.Accounts.Include(a => a.Repairs).ToList();
                
            }

            Console.ReadLine();
        }
    }
}
