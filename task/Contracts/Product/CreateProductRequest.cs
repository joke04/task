namespace task.Contracts.Product
{
    public class CreateProductRequest
    {
        public int IdCategories { get; set; }
        public string Namee { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; } = null!;
        public int Article { get; set; }
    }
}
