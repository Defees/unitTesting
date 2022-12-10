using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using unittesting.Entities;
using unittesting.Interfaces.Repos;
using unittesting.Models;

namespace unittesting.Repos
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetCustomerOrders(int id)
        {
            return _context.Set<Order>().Include(c => c.Customer).Where(c => c.CustomerId == id).ToList();
        }

        public void UpdateCustomer(int id, string name)
        {
            _context.Set<Customer>().FirstOrDefault(customer => customer.Id == id).Name = name;
        }
    }
}
