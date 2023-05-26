namespace task.Contracts.Category
{
    public class GetCategoryRequest
    {
        public int IdCategories { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
