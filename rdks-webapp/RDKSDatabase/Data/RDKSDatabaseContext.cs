using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RDKSDatabase.Models;
using RDKSDatabase.ViewModels;

namespace RDKSDatabase.Data
{
    public class RDKSDatabaseContext : DbContext
    {
        public RDKSDatabaseContext (DbContextOptions<RDKSDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<ABCRecycling>? ABCRecycling { get; set; }

        public DbSet<Address>? Address { get; set; }

        public DbSet<Customer>? Customer { get; set; }

        public DbSet<HWY37N_HAZELTON>? HWY37N_HAZELTON { get; set; }

        public DbSet<HWY37N_KITWANGA>? HWY37N_KITWANGA { get; set; }

        public DbSet<HWY37N_STEWART>? HWY37N_STEWART { get; set; }

        public DbSet<Permit>? Permit { get; set; }

        public DbSet<Transaction>? Transaction { get; set; }

        public DbSet<Validation>? Validation { get; set; }

        public DbSet<Vehicle>? Vehicle { get; set; }

        public DbSet<Material>? Material { get; set; }

        public DbSet<WasteSource>? WasteSource { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permit>()
                .HasKey(p => new { p.PermitNumberPrefix, p.PermitNumber });
            modelBuilder.Entity<CustomerInfo>()
                .HasNoKey();
        }

    }
}
