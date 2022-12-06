namespace unittesting.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
     

    }
}
