namespace task.Contracts.SavedAddress
{
    public class GetSavedAddressRequest
    {
        public int UserIdd { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int House { get; set; }
        public int Construction { get; set; }
        public int Flat { get; set; }
        public string AddressName { get; set; } = null!;
    }
}
