using Microsoft.AspNetCore.Mvc;
using vidoGameapi.Models;

namespace vidoGameapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>()
        {
            new VideoGame
            {
                Id = 1,
                Title = "spider-man 2",
                Platform = "ps5",
                Developer = "insomniac games",
                Publisher = "sony interactive entertainment",
            },
            new VideoGame
            {
                Id = 2,
                Title = "the last of us part 1",
                Platform = "ps5",
                Developer = "naughty dog",
                Publisher = "sony interactive entertainment"
            },
            new VideoGame
            {
                Id  = 3,
                Title = "the legend of zelda: breath of the wild",
                Platform = "nintendo switch",
                Developer = "nintendo",
                Publisher = "nintendo"
            }
        };

        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGame()
        {
            return Ok(videoGames);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<VideoGame>> GetVideoGameById(int id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
                if (game is null)
                    return NotFound();
            return Ok(game);
        }
        [HttpPost]
        public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest();

            newGame.Id = videoGames.Max(g => g.Id) + 1;
            videoGames.Add(newGame);
            //return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
            return Ok();
        }
    }
} 