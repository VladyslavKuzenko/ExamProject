using EasyLearn.Data;
using EasyLearn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Nomenclatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetNomenclature()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Nomenclatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetNomenclature(int id)
        {
            var nomenclature = await _context.User.FindAsync(id);

            if (nomenclature == null)
            {
                return NotFound();
            }

            return nomenclature;
        }

        // PUT: api/Nomenclatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomenclature(int id, User nomenclature)
        {
            if (id != nomenclature.Id)
            {
                return BadRequest();
            }

            _context.Entry(nomenclature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomenclatureExists(id))
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

        // POST: api/Nomenclatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostNomenclature(User nomenclature)
        {
            _context.User.Add(nomenclature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNomenclature", new { id = nomenclature.Id }, nomenclature);
        }

        // DELETE: api/Nomenclatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomenclature(int id)
        {
            var nomenclature = await _context.User.FindAsync(id);
            if (nomenclature == null)
            {
                return NotFound();
            }

            _context.User.Remove(nomenclature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NomenclatureExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
