namespace task.Contracts.Ordering
{
    public class CreateOrderingRequest
    {
        public DateTime DateAndTimeReferences { get; set; }
        public string Statuss { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
