using unittesting.Entities;
using unittesting.Interfaces.Repos;

namespace unittesting.Repos
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
