using Microsoft.EntityFrameworkCore;

namespace BugRepro
{
    class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
