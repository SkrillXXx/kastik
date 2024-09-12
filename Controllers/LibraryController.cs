
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KAsT_aPi.Models;

namespace KAst_api.Controllers
{
    [ApiController]
    [Route("Library")]
    public class LibraryController : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new KastContext();
            return Ok(db.Libraries);
        }
        [HttpPost]
        public IActionResult Add(Library library)
        {
            var db = new KastContext();
            db.Set<Library>().Add(library);
            db.SaveChanges();
            return Ok(db.Libraries);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetLibrary(int id)
        {
            var db = new KastContext();
            List<Library> libraries = new List<Library>();
            foreach (var library in db.Libraries)
            {
                libraries.Add(library);
            }
            Library CurrentLibrary = libraries.FirstOrDefault(u => u.Id == id);
            if (CurrentLibrary == null) return NotFound();
            return Ok(CurrentLibrary);
        }
        [HttpPut]
        public IActionResult Update(Library library)
        {
            var db = new KastContext();
            db.Set<Library>().Update(library);
            db.SaveChanges();
            return Ok(library);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new KastContext();
            List<Library> libraries = new List<Library>();
            foreach (var library in db.Libraries)
            {
                libraries.Add(library);
            }
            Library CurrentLibrary = libraries.FirstOrDefault(u => u.Id == id);
            if (CurrentLibrary == null) return NotFound();
            db.Libraries.Remove(CurrentLibrary);
            db.SaveChanges();
            return Ok();
        }
    }
}