using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerManagementDAL;

namespace PlayerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerManageController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PlayerManageController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _db.Players.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Player>> AddPlayer(Player player)
        {
            _db.Players.Add(player);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, player);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayerById(int id)
        {
            var player = await _db.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        [HttpGet("byage/{age}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersByAge(int age)
        {
            var players = await _db.Players.Where(p => DateTime.Now.Year - p.BirthDate.Year == age).ToListAsync();

            if (players == null)
            {
                return NotFound();
            }

            return players;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            _db.Entry(player).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _db.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            _db.Players.Remove(player);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
