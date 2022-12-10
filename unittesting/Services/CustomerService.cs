using AutoMapper;
using unittesting.Entities;
using unittesting.Interfaces;
using unittesting.Models;

namespace unittesting.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void CreateCustomer(string name)
        {
             _unitOfWork.Customers.Add(new Customer() { Name = name});
            _unitOfWork.Complete();
        }

        public void DeleteCustomer(int id)
        {
            _unitOfWork.Customers.Remove(GetCustomer(id));
            _unitOfWork.Complete();
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        { 
            return _unitOfWork.Customers.GetAllInclude<List<Order>>(c => c.Orders)
                .Select(c => _mapper.Map<Customer, CustomerModel>(c)).ToList(); 
        }

        public Customer GetCustomer(int id)
        {
            return _unitOfWork.Customers.GetById(id);
        }

        public IEnumerable<OrderModel> GetCustomerOrders(int customerId)
        {
            return _unitOfWork.Customers.GetCustomerOrders(customerId)
                .Select(c => _mapper.Map<Order, OrderModel>(c)).ToList();
        }

        public void UpdateCustomer(int id, string name)
        {
            _unitOfWork.Customers.UpdateCustomer(id, name);
            _unitOfWork.Complete();
        }
    }
}
