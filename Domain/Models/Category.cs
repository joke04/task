using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int IdCategories { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual Filter? Filter { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
