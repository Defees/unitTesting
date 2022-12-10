using unittesting.Entities;

namespace unittesting.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
