using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerManagementDAL;

namespace PlayerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamManageController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TeamManageController(AppDbContext db)
        {
            _db = db;
        }
        // Get All Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _db.Teams.ToListAsync();
        }


        // Get team by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _db.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // Create a new team
        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam(Team team)
        {
            _db.Teams.Add(team);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _db.Entry(team).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TeamExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return NoContent();
        }

        //[NonAction]
        //private bool TeamExists(int id)
        //{
        //    return _db.Teams.Any(t => t.Id == id);
        //}



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _db.Teams.Remove(team);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/players")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersByTeam(int id)
        {
            var players = await _db.Players.Where(p => p.TeamId == id).ToListAsync();

            if (players == null || players.Count == 0)
            {
                return NotFound();
            }

            return players;
        }
    }
}
