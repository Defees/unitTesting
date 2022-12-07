using unittesting.Entities;

namespace unittesting.Interfaces
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetCustomer(int id);
        public IEnumerable<Order> GetCustomerOrders(int id);
        public void CreateCustomer(string name);
        public void DeleteCustomer(int id);
        public void UpdateCustomer(int id, string name);

    }
}
