using unittesting.Interfaces.Repos;

namespace unittesting.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        int Complete();
    }
}
