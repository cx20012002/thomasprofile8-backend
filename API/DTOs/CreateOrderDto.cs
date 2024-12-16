using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public string OrderNumber { get; set; }

        public string UserAuthId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Email { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public List<OrderProductDto> Products { get; set; }
    }
}