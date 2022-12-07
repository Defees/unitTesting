using unittesting.Entities;

namespace unittesting.Interfaces
{
    public interface IOrderService
    {
        public Order GetOrder(int id);
        public void CreateOrder(int customerId, string code);
        public void DeleteOrder(int id);
        public void UpdateOrder(int id, string code);
    }
}
