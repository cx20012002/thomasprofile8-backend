using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Entities.Order
{
    [Owned]
    public class ProductItemOrdered
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public long Price { get; set; }
        public string PictureUrl { get; set; }
    }
}