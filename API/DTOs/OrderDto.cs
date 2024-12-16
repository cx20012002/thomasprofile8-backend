namespace API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string UserAuthId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string Currency { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderProductDto> Products { get; set; }
    }
}