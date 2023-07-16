using Microsoft.EntityFrameworkCore;
using UniWeb.Data;
using UniWeb.Data.Models;

namespace UniWeb.Services
{
    public class CustomerService
    {
        private IDbContextFactory<AppDbContext> _dbContextFactory;

        public CustomerService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddCustomer(Customer customer)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Customer.Add(customer);
            }
        }
    }
}
