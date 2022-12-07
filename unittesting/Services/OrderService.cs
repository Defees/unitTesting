using unittesting.Entities;
using unittesting.Interfaces;

namespace unittesting.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateOrder(int customerId, string code)
        {
            _unitOfWork.Orders.Add(new Order(customerId, code));
            _unitOfWork.Complete();
        }

        public void DeleteOrder(int id)
        {
            _unitOfWork.Orders.Remove(GetOrder(id));
            _unitOfWork.Complete();
        }

        public Order GetOrder(int id)
        {
           return _unitOfWork.Orders.GetById(id);
        }

        public void UpdateOrder(int id, string code)
        {
            _unitOfWork.Orders.UpdateOrder(id, code);
            _unitOfWork.Complete();
        }
    }
}
