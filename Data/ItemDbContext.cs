using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ItemDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the model using the Fluent API here
            // For example:
            // modelBuilder.Entity<Item>().HasKey(i => i.ItemId);
        }
    }
}
