namespace task.Contracts.Ordering
{
    public class GetOrderingRequest
    {
        public int OrderNumber { get; set; }
        public int UserIdd { get; set; }
        public int NumberProduct { get; set; }
        public DateTime DateAndTimeReferences { get; set; }
        public string Statuss { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
