using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Entities.Order
{
    public class OrderProduct
    {
        public int Id { get; set; }
        [Required]
        public ProductItemOrdered ItemOrdered { get; set; }
        public int Quantity { get; set; }
    }
}