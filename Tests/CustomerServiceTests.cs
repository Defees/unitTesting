using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Castle.Core.Resource;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using unittesting.AutoMapper;
using unittesting.Entities;
using unittesting.Interfaces;
using unittesting.Interfaces.Repos;
using unittesting.Models;
using unittesting.Services;
using Xunit;

namespace Tests
{
    public class CustomerServiceTests
    {
        private static IMapper _mapper;

        public CustomerServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AppMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        public void GetAllCustomers_IsAssignableFromCustomer_True()
        {
            //arrange 
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository
                .Setup(repo => repo.GetAll())
                .Returns(GetTestCustomers());

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(uow => uow.Customers)
                .Returns(mockCustomerRepository.Object);

            var customerService = new CustomerService(mockUnitOfWork.Object, _mapper);

            //act
            var result = customerService.GetCustomers();

            //assert
            mockCustomerRepository.Verify(r => r.GetAll());
            Assert.IsAssignableFrom<IEnumerable<Customer>>(result);
            
        }

        [Fact]
        public void GetCustomersWithOrders_IsAssignableFromCustomerModel_True()
        {
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository
                .Setup(repo => repo.GetAllInclude<List<Order>>(c => c.Orders))
                .Returns(GetTestCustomersWithOrders());

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(uow => uow.Customers)
                .Returns(mockCustomerRepository.Object);

            var customerService = new CustomerService(mockUnitOfWork.Object, _mapper);

            //act
            var result = customerService.GetAllCustomersWithOrders();

            //assert
            mockCustomerRepository.Verify(r => r.GetAllInclude<List<Order>>(c => c.Orders));
            Assert.IsAssignableFrom<IEnumerable<CustomerModel>>(result);
            Assert.IsAssignableFrom<IEnumerable<OrderModel>>(result.FirstOrDefault().Orders);
        }

        [Fact]
        public void UpdateCustomer_EqualToUpdatedCustomer_True()
        {
            //arrange 
            var customer = new Customer { Id = 1, Name = "Ivan" };

            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository
                .Setup(repo => repo.GetById(1))
                .Returns(customer);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(uow => uow.Customers)
                .Returns(mockCustomerRepository.Object);

            var customerService = new CustomerService(mockUnitOfWork.Object, _mapper);

            //act
            customerService.UpdateCustomer(1, "Dima");

            //assert
            mockCustomerRepository.Verify(r => r.GetById(1));
            mockUnitOfWork.Verify(uow => uow.Complete());
            Assert.Equal("Dima", customer.Name);
        }

        [Fact] 
        public void AddCustomer_VerifyAdd()
        {
            //arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork
                .Setup(uow => uow.Customers)
                .Returns(mockCustomerRepository.Object);

            var customerService = new CustomerService(mockUnitOfWork.Object, _mapper);

            //act
            customerService.CreateCustomer("ivan");

            //assert
            mockCustomerRepository.Verify(r => r.Add(It.IsAny<Customer>()));
            mockUnitOfWork.Verify(uow => uow.Complete());
        }

        private List<Customer> GetTestCustomers()
        {
            var random = new Random();

            List<Customer> customers = new List<Customer>();

            for(int i = 1; i < 6; i++)
            {
                customers.Add(new Customer { Id = i, Name = names[random.Next(names.Count)] });
            }

            return customers;
        }

        
        private List<Customer> GetTestCustomersWithOrders()
        {
            var random = new Random();

            List<Customer> customers = new List<Customer>();

            for (int i = 1; i < 6; i++)
            {
                customers.Add(new Customer { Id = i, Name = names[random.Next(names.Count)], Orders = GetTestOrders(i)});
            }
            return customers;

        }

        private List<Order> GetTestOrders(int customerId)
        {
            return new List<Order>
            {
                new Order{ Id = 1, Code = "232123", CustomerId = customerId},
                new Order{ Id = 2, Code = "332123", CustomerId = customerId},
                new Order{ Id = 3, Code = "432123", CustomerId = customerId},
                new Order{ Id = 4, Code = "532123", CustomerId = customerId}

            };
        }

        private List<string> names = new List<string> { "Ivan", "Petro", "Pavlo", "Ruslan" };
    }
}
