using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerManagementDAL;

namespace PlayerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachManageController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CoachManageController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/Coach
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coach>>> GetCoaches()
        {
            return await _db.Coaches.ToListAsync();
        }

        // GET: api/Coach/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coach>> GetCoach(int id)
        {
            var coach = await _db.Coaches.FindAsync(id);

            if (coach == null)
            {
                return NotFound();
            }

            return coach;
        }

        // PUT: api/Coach/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoach(int id, Coach coach)
        {
            if (id != coach.Id)
            {
                return BadRequest();
            }

            _db.Entry(coach).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachExists(id))
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

        // POST: api/Coach
        [HttpPost]
        public async Task<ActionResult<Coach>> PostCoach(Coach coach)
        {
            _db.Coaches.Add(coach);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetCoach", new { id = coach.Id }, coach);
        }

        // DELETE: api/Coach/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            var coach = await _db.Coaches.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }

            _db.Coaches.Remove(coach);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool CoachExists(int id)
        {
            return _db.Coaches.Any(e => e.Id == id);
        }
    }
}
