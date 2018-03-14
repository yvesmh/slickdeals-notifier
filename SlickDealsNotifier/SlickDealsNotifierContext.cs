using System;
using Microsoft.EntityFrameworkCore;
namespace SlickDealsNotifier
{
    public class SlickDealsNotifierContext : DbContext
    {
        public DbSet<Deal> Deals { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            //TODO move to config file
            optionsBuilder.UseSqlite("Data Source=slickdeals.db");
        }
    }
}
