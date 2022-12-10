using unittesting.Entities;
using unittesting.Models;

namespace unittesting.Interfaces
{
    public interface ICustomerService
    {
        public IEnumerable<CustomerModel> GetAllCustomers();
        public Customer GetCustomer(int id);
        public IEnumerable<OrderModel> GetCustomerOrders(int id);
        public void CreateCustomer(string name);
        public void DeleteCustomer(int id);
        public void UpdateCustomer(int id, string name);

    }
}
