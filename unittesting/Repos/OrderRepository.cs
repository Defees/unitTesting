using unittesting.Entities;
using unittesting.Interfaces.Repos;

namespace unittesting.Repos
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void UpdateOrder(int orderId, string code)
        {
            _context.Set<Order>().FirstOrDefault(order => order.Id == orderId).Code = code;
        }
    }
}
