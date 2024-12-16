namespace API.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public int Stock { get; set; }
        public string PictureUrl { get; set; }
        public List<int> CategoryIds { get; set; }
        // Add other properties as needed
    }
} 