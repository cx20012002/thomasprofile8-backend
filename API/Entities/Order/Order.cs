using System.ComponentModel.DataAnnotations;

namespace API.Entities.Order
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string StripeCheckoutSessionId { get; set; }
        public string StripeCustomerId { get; set; }
        public string UserAuthId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string StripePaymentIntentId { get; set; }
        
        public List<OrderProduct> Products { get; set; } = [];
        public decimal TotalPrice { get; set; }
        public string Currency { get; set; }
        
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime OrderDate { get; set; }
    }
}