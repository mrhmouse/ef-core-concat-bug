using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace BugRepro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = new SqlConnectionStringBuilder
            {
                InitialCatalog = "BugRepro",
                IntegratedSecurity = true,
                DataSource = "(local)",
            }.ConnectionString;
            var dbOptions = new DbContextOptionsBuilder<CoreContext>()
                .UseSqlServer(connectionString)
                .Options;

            var ef6Context = new EF6Context(connectionString);
            var coreContext = new CoreContext(dbOptions);

            Console.WriteLine("Press [ENTER] to run EF6 query:");
            Console.ReadLine();
            var ef6AddressIds = CustomerAddressIds(ef6Context.Customers, 4);
            var ef6Addresses = ef6Context.Addresses.Where(a => ef6AddressIds.Contains(a.Id));
            foreach (var address in ef6Addresses)
                Console.WriteLine($"- {address.Label}");

            Console.WriteLine("Press [ENTER] to run EFCore query:");
            Console.ReadLine();
            var coreAddressIds = CustomerAddressIds(coreContext.Customers, 4);
            var coreAddresses = coreContext.Addresses.Where(a => coreAddressIds.Contains(a.Id));
            foreach (var address in coreAddresses)
                Console.WriteLine($"- {address.Label}");

            Console.WriteLine("Press [ENTER] to exit:");
            Console.ReadLine();
        }

        static IQueryable<int> CustomerAddressIds(IQueryable<Customer> customers, int customerId)
        {
            return customers
                .Where(c => c.Id == customerId)
                .Select(c => c.AddressId1)
                .Concat(customers.Select(c => c.AddressId2))
                .Where(id => id.HasValue)
                .Select(id => id.Value);
        }
    }
}
