using unittesting.Entities;
using unittesting.Interfaces.Repos;

namespace unittesting.Repos
{
    public class OrderEFRepository : GenericEFRepository<Order>, IOrderRepository
    {
        public OrderEFRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
