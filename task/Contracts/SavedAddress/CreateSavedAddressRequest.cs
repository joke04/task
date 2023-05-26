namespace task.Contracts.SavedAddress
{
    public class CreateSavedAddressRequest
    {
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int House { get; set; }
        public int Construction { get; set; }
        public int Flat { get; set; }
    }
}
