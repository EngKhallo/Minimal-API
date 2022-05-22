using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal_API.Data;
using Minimal_API.Models;

namespace Minimal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book_AuthorController : ControllerBase
    {
        private readonly Minimal_APIContext _context;

        public Book_AuthorController(Minimal_APIContext context)
        {
            _context = context;
        }

        // GET: api/Book_Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book_Author>>> GetBook_Author()
        {
          if (_context.Book_Author == null)
          {
              return NotFound();
          }
            return await _context.Book_Author.ToListAsync();
        }

        // GET: api/Book_Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book_Author>> GetBook_Author(int id)
        {
          if (_context.Book_Author == null)
          {
              return NotFound();
          }
            var book_Author = await _context.Book_Author.FindAsync(id);

            if (book_Author == null)
            {
                return NotFound();
            }

            return book_Author;
        }

        // PUT: api/Book_Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook_Author(int id, Book_Author book_Author)
        {
            if (id != book_Author.Id)
            {
                return BadRequest();
            }

            _context.Entry(book_Author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Book_AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Book_Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book_Author>> PostBook_Author(Book_Author book_Author)
        {
          if (_context.Book_Author == null)
          {
              return Problem("Entity set 'Minimal_APIContext.Book_Author'  is null.");
          }
            _context.Book_Author.Add(book_Author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook_Author", new { id = book_Author.Id }, book_Author);
        }

        // DELETE: api/Book_Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook_Author(int id)
        {
            if (_context.Book_Author == null)
            {
                return NotFound();
            }
            var book_Author = await _context.Book_Author.FindAsync(id);
            if (book_Author == null)
            {
                return NotFound();
            }

            _context.Book_Author.Remove(book_Author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Book_AuthorExists(int id)
        {
            return (_context.Book_Author?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
