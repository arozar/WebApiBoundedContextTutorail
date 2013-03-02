using Accounts.Domain;
using Base.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Context
{
    public class AccountsContext : BaseContext<AccountsContext>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<RepairPart> Repairparts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //map foreign key relationship
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Repairs)
                .WithRequired()
                .Map(m =>
                {
                    m.MapKey("AccountId")
                        .ToTable("Repairs");
                });
            //map many to many relationship
            modelBuilder.Entity<Worker>()
                .HasMany(w => w.Tasks)
                .WithMany()
                .Map(m =>
                {
                    m.MapRightKey("Repair_Id");
                    m.MapLeftKey("Worker_Id");
                    m.ToTable("WorkerRepairs");
                });


            modelBuilder.Entity<RepairPart>().HasKey(rp => new { rp.ComponentId, rp.RepairId });            

            base.OnModelCreating(modelBuilder);
        }
    }
}
