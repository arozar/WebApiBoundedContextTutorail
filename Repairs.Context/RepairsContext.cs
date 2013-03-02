using Base.Context;
using Repairs.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repairs.Context
{
    public class RepairsContext :BaseContext<RepairsContext>
    {
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairPart> RepairPart { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Worker> Workers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Repair>()
               .HasMany(r => r.Team)
               .WithMany()
               .Map(x =>
               {
                   x.MapLeftKey("Repair_Id");
                   x.MapRightKey("Worker_Id");
                   x.ToTable("WorkerRepairs");
               });

           modelBuilder.Entity<RepairPart>()
               .HasKey(rp => new { rp.ComponentId, rp.RepairId });
            
        }
    }
}
