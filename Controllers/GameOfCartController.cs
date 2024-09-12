using KAsT_aPi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KAst_api.Controllers
{
    [ApiController]
    [Route("GameOfCart")]
    public class GameOfCartController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new KastContext();
            return Ok(db.GameOfCarts);
        }
        [HttpPost]
        public IActionResult Add(GameOfCart gameOfCart)
        {
            var db = new KastContext();
            db.Set<GameOfCart>().Add(gameOfCart);
            db.SaveChanges();
            return Ok(db.GameOfCarts);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGameOfCart(int id)
        {
            var db = new KastContext();
            List<GameOfCart> gameOfCarts  = new List<GameOfCart>();
            foreach (var gameOfcart in db.GameOfCarts)
            {
                gameOfCarts.Add(gameOfcart);
            }
            GameOfCart CurrentGameOfCart = gameOfCarts.FirstOrDefault(u => u.Id == id);
            if (CurrentGameOfCart == null) return NotFound();
            return Ok(CurrentGameOfCart);
        }
        [HttpPut]
        public IActionResult Update(GameOfCart gameOfCart)
        {
            var db = new KastContext();
            db.Set<GameOfCart>().Update(gameOfCart);
            db.SaveChanges();
            return Ok(gameOfCart);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new KastContext();
            List<GameOfCart> gameOfCarts = new List<GameOfCart>();
            foreach (var gameOfcart in db.GameOfCarts)
            {
                gameOfCarts.Add(gameOfcart);
            }
            GameOfCart CurrentGameOfCart = gameOfCarts.FirstOrDefault(u => u.Id == id);
            if (CurrentGameOfCart == null) return NotFound();
            db.GameOfCarts.Remove(CurrentGameOfCart);
            db.SaveChanges();
            return Ok();
        }
    }
}

