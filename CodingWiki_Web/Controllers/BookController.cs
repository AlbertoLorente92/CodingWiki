using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db; 

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objList = _db.Books.ToList();
            return View(objList);
        }


        public IActionResult Upsert(int? id)
        {
            Book obj = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }
            obj = _db.Books.FirstOrDefault(u => u.IdBook == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new();
            obj = _db.Books.FirstOrDefault(u => u.IdBook == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Book obj)
        {
            if(ModelState.IsValid) 
            { 
                if(obj.IdBook == 0)
                {
                    // create
                    await _db.Books.AddAsync(obj);
                }
                else
                {
                    // update
                    _db.Books.Update(obj);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }
    }
}
