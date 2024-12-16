using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class FoodController : BaseApiController
    {
        private readonly StoreContext _context;

        public FoodController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Food>>> GetFoods()
        {
            var foods = await _context.Foods.ToListAsync();
            if (foods == null) return NotFound();
            return Ok(foods);
        }
    }
}