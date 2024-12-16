using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SubscriberController : BaseApiController
    {
        private readonly StoreContext _context;

        public SubscriberController(StoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Subscriber>> CreateSubscriber([FromBody] Subscriber subscriber)
        {
            // check to see if the subscriber email is already exists
            if (await _context.Subscribers.AnyAsync(s => s.Email == subscriber.Email))
            {
                return BadRequest(new ProblemDetails { Title = "Email already exists", Status = 400 });
            }

            _context.Subscribers.Add(subscriber);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSubscribers), new { id = subscriber.Id }, new { message = "Subscriber created successfully", status = 201 });
        }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<List<Subscriber>>> GetSubscribers()
            {
                return await _context.Subscribers.ToListAsync();
            }

            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<Subscriber>> DeleteSubscriber(int id)
            {
                var subscriber = await _context.Subscribers.FindAsync(id);
                if (subscriber == null) return NotFound();

                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }