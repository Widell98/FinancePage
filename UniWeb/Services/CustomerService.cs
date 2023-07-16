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
                context.SaveChanges();
            }
        }

        public Customer getCustomerByName(string name)
        {
            using var context = _dbContextFactory.CreateDbContext();
            {
                var customer = context.Customer.FirstOrDefault(x => x.Name == name);
                return customer;
            }
        }

        public void UpdateCustomer(string name, int age)
        {
            var customer = getCustomerByName(name);
            if (customer == null)
            {
                throw new Exception("Customer does not exist. Cannot update");

            }
            customer.Age = age;
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Update(customer);
                context.SaveChanges();
            }
        }
    }
}
