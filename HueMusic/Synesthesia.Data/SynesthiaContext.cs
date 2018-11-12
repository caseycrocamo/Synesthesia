using Microsoft.EntityFrameworkCore;
using Synesthesia.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Synesthesia.Data
{
    public class SynesthiaContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=Synesthesia;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True");
        }
    }
}
