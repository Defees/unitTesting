using unittesting.Entities;

namespace unittesting.Interfaces.Repos
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public void UpdateOrder(int id, string code);
    }
}
