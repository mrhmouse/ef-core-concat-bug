using System.Data.Entity;

namespace BugRepro
{
    class EF6Context : DbContext
    {
        public EF6Context(string connectionString)
        : base(connectionString) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}
