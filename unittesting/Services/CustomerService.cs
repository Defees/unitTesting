using unittesting.Entities;
using unittesting.Interfaces;

namespace unittesting.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateCustomer(string name)
        {
            _unitOfWork.Customers.Add(new Customer(name));
            _unitOfWork.Complete();
        }

        public void DeleteCustomer(int id)
        {
            _unitOfWork.Customers.Remove(GetCustomer(id));
            _unitOfWork.Complete();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _unitOfWork.Customers.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return _unitOfWork.Customers.GetById(id);
        }

        public IEnumerable<Order> GetCustomerOrders(int customerId)
        {
            return _unitOfWork.Customers.GetCustomerOrders(customerId);
        }

        public void UpdateCustomer(int id, string name)
        {
            _unitOfWork.Customers.UpdateCustomer(id, name);
            _unitOfWork.Complete();
        }
    }
}
