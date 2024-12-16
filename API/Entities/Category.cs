namespace API.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        // Navigation property for the many-to-many relationship with Product
        public ICollection<Product> Products { get; set; }
    }
} 