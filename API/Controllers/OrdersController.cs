using API.Data;
using API.DTOs;
using API.Entities.Order;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class OrdersController : BaseApiController
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        public OrdersController(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderDto>> CreateOrder(CreateOrderDto orderDto, CancellationToken cancellationToken)
        {
            // Update prices from database
            foreach (var orderProduct in orderDto.Products)
            {
                var productFromDb = await _context.Products.FindAsync(orderProduct.ProductId);
                if (productFromDb == null)
                    return BadRequest($"Product with id {orderProduct.ProductId} not found");

                // Update to correct price from database
                orderProduct.Price = productFromDb.Price;
                orderProduct.Name = productFromDb.Name; // Optionally ensure name is correct too
            }

            var order = new Order
            {
                OrderNumber = orderDto.OrderNumber,
                UserAuthId = orderDto.UserAuthId,
                CustomerName = orderDto.CustomerName,
                Email = orderDto.Email,
                Status = Enum.Parse<OrderStatus>(orderDto.Status),
                TotalPrice = orderDto.TotalPrice,
                Currency = orderDto.Currency,
                OrderDate = orderDto.OrderDate,
                Products = orderDto.Products.Select(p => new OrderProduct
                {
                    Quantity = p.Quantity,
                    ItemOrdered = new ProductItemOrdered
                    {
                        ProductId = p.ProductId,
                        Name = p.Name.ToLower(),
                        Price = p.Price,
                        PictureUrl = p.PictureUrl
                    }
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, _mapper.Map<OrderDto>(order));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders(string email, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                .AsNoTracking()
                .Include(o => o.Products)
                .ThenInclude(p => p.ItemOrdered)
                .Where(o => o.Email == email)
                .ToListAsync(cancellationToken);


            if (orders.Count == 0)
                return NotFound(new { message = "No orders found" });

            return Ok(_mapper.Map<List<OrderDto>>(orders));
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Order>> GetOrder(int id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
             .AsNoTracking()
             .Include(o => o.Products)
             .ThenInclude(p => p.ItemOrdered)
             .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

            if (order == null)
                return NotFound(new { message = "No orders found" });

            return Ok(_mapper.Map<OrderDto>(order));
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrder(int id, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(new object[] { id }, cancellationToken);
            if (order == null)
                return NotFound(new { message = "Order not found" });

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

    }
}