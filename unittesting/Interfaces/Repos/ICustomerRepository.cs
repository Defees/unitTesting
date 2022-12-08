using unittesting.Entities;

namespace unittesting.Interfaces.Repos
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public IEnumerable<Order> GetCustomerOrders(int id);
        public void UpdateCustomer(int id, string name);
    }
}
