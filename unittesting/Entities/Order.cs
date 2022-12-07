namespace unittesting.Entities
{
    public class Order
    {
        public Order(int customerId, string code)
        {
            CustomerId = customerId;
            Code = code;
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
     

    }
}
