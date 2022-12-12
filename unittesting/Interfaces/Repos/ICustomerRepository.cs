using unittesting.Entities;
using unittesting.Models;

namespace unittesting.Interfaces.Repos
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public IEnumerable<Order> GetCustomerOrders(int id);
    }
}
