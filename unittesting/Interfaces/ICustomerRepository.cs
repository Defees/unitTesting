using unittesting.Entities;

namespace unittesting.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public IEnumerable<Order> GetCustomerOrders(int id);
        public void UpdateCustomer(int id, string name);
    }
}
