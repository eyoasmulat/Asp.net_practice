using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using vidoGameapi.Data;

namespace vidoGameapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        private readonly VideoGameDbContext _context = context;
        [HttpGet]
        public async  Task<ActionResult<List<VideoGame>>> GetVideoGame()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();
            return Ok(game);
        }
        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest();

            //newGame.Id = videoGames.Max(g => g.Id) + 1;
            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
            //return Ok();
        }
        [HttpPut("{id}")]

        public async  Task<IActionResult> UpdateVideoGame(int id, VideoGame updatesGame)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();
            game.Title = updatesGame.Title;
            game.Platform = updatesGame.Platform;
            game.Developer = updatesGame.Developer;
            game.Publisher = updatesGame.Publisher;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();
            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}