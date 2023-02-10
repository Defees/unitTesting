using AutoMapper;
using Microsoft.Extensions.Configuration;
using unittesting.Interfaces;
using unittesting.Interfaces.Repos;
using unittesting.Repos;

namespace unittesting
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public UnitOfWork(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            Customers = new CustomerEFRepository(_context);
            Orders = new OrderDapperRepository(_configuration.GetConnectionString("DefaultConnection"));
        }
        public ICustomerRepository Customers { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
