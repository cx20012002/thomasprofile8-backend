using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ContactController : BaseApiController
    {
        private readonly StoreContext _context;

        public ContactController(StoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contact>> CreateContact([FromBody] Contact contact)
        {
            // check the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contacts.Add(contact);
            var results = await _context.SaveChangesAsync() > 0;
            if (!results) return BadRequest(new ProblemDetails { Title = "Failed to create contact", Status = 400 });

            return CreatedAtAction(nameof(GetContacts), new { id = contact.Id }, new { message = "Contact created successfully", status = 201 });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null) return NotFound();

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}