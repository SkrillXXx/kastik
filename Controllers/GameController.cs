using KAsT_aPi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KAst_api.Controllers
{
    [ApiController]
    [Route("Game")]
    public class GameController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new KastContext();
            return Ok(db.Games);
        }
        [HttpPost]
        public IActionResult Add(Game game)
        {
            var db = new KastContext();
            db.Set<Game>().Add(game);
            db.SaveChanges();
            return Ok(db.Games);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGameOfCart(int id)
        {
            var db = new KastContext();
            List<Game> game = new List<Game>();
            foreach (var games in db.Games)
            {
                game.Add(games);
            }
            Game CurrentGame = game.FirstOrDefault(u => u.Id == id);
            if (CurrentGame == null) return NotFound();
            return Ok(CurrentGame);
        }
        [HttpPut]
        public IActionResult Update(Game game)
        {
            var db = new KastContext();
            db.Set<Game>().Update(game);
            db.SaveChanges();
            return Ok(game);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new KastContext();
            List<Game> game = new List<Game>();
            foreach (var games in db.Games)
            {
                game.Add(games);
            }
            Game CurrentGame = game.FirstOrDefault(u => u.Id == id);
            if (CurrentGame == null) return NotFound();
            db.Games.Remove(CurrentGame);
            db.SaveChanges();
            return Ok();
        }
    }
}
