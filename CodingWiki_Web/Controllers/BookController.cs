using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            List<Book> objList = _db.Books.Include(u => u.Publisher).ToList();  // bestway
            //foreach(var obj in objList)
            //{
            //    // obj.Publisher = _db.Publishers.Find(obj.Publisher_id); // muy costoso
            //
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();          // lo carga una vez y lo mantiene
            //}
            return View(objList);
        }


        public IActionResult Upsert(int? id)
        {
            BookVM obj = new();

            obj.PublisherList = _db.Publishers.Select(cust =>  new SelectListItem
            { 
                Text = cust.Name,
                Value = cust.Publisher_Id.ToString()
            });

            if (id == null || id == 0)
            {
                return View(obj);
            }

            obj.Book = _db.Books.FirstOrDefault(u => u.IdBook == id);
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
        public async Task<IActionResult> Upsert(BookVM obj)
        {

            if(obj.Book.IdBook == 0)
            {
                // create
                await _db.Books.AddAsync(obj.Book);
            }
            else
            {
                // update
                _db.Books.Update(obj.Book);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            //BookVM obj = new();
            //
            //if (id == null || id == 0)
            //{
            //    return NotFound();
            //}
            //
            //obj.Book = _db.Books.FirstOrDefault(u => u.IdBook == id);
            //obj.Book.BookDetail1 = _db.BookDetails.FirstOrDefault(u => u.Book_Id == id);
            //if (obj == null)
            //{
            //    return NotFound();
            //}
            //return View(obj);
            if (id == null || id == 0)
            {
                return NotFound();
            }

            BookDetail obj = new();
            //obj.Book = _db.Books.FirstOrDefault(u => u.IdBook == id);
            //obj = _db.BookDetails.FirstOrDefault(u => u.Book_Id == id);
            obj = _db.BookDetails.Include(u => u.Book).FirstOrDefault(u => u.Book_Id == id);        //eager loading
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail obj)
        {
            if (obj.BookDetail_Id == 0)
            {
                // create
                await _db.BookDetails.AddAsync(obj);
            }
            else
            {
                // update
                _db.BookDetails.Update(obj);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM obj = new()
            {
                BookAuthorList = _db.BookAuthorMaps
                .Include(u => u.Author)
                .Include(u => u.Book)
                .Where(u => u.Book_Id == id)
                .ToList(),
                BookAuthor = new() { Book_Id = id},
                Book = _db.Books.FirstOrDefault(u => u.IdBook == id)
            };

            List<int> tempListOfAssignerAuthor = obj.BookAuthorList.Select(u => u.Author_Id).ToList();

            // NOT IN
            // get all the authors whos id is not in tempListOfAssignerAuthor
            var tempList = _db.Authors.Where(u => !tempListOfAssignerAuthor.Contains(u.Author_Id)).ToList();
            obj.AuthorList = tempList.Select(
                i => new SelectListItem
                {
                    Text = i.FullName,
                    Value = i.Author_Id.ToString()
                }
            );

            return View(obj);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            if(bookAuthorVM.BookAuthor.Book_Id != 0 && bookAuthorVM.BookAuthor.Author_Id != 0)
            {
                _db.BookAuthorMaps.Add(bookAuthorVM.BookAuthor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVM.BookAuthor.Book_Id });
        }

        [HttpPost]
        public IActionResult RemoveAuthors(int authorId, BookAuthorVM bookAuthorVM)
        {
            int bookId = bookAuthorVM.Book.IdBook;
            BookAuthorMap bookAuthorMap = _db.BookAuthorMaps.FirstOrDefault(
                u => u.Author_Id == authorId && u.Book_Id == bookId    
            );

            _db.BookAuthorMaps.Remove(bookAuthorMap);
            _db.SaveChanges();
            
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }

        public async Task<IActionResult> PlayGround()
        {
            //updating related data
            var bookDetails1 = _db.BookDetails.Include(b => b.Book).FirstOrDefault(b => b.BookDetail_Id == 4);
            bookDetails1.NumberOfChapters = 2222;
            bookDetails1.Book.Price = 222;
            _db.BookDetails.Update(bookDetails1);
            await _db.SaveChangesAsync();

            var bookDetails2 = _db.BookDetails.Include(b => b.Book).FirstOrDefault(b => b.BookDetail_Id == 4);
            bookDetails2.NumberOfChapters = 1111;
            bookDetails2.Book.Price = 111;
            _db.BookDetails.Attach(bookDetails2);
            await _db.SaveChangesAsync();

            //IEnumerable<Book> booklist1 = _db.Books;                // aplica el WHERE en memoria (lento)
            //var filterBook1 = booklist1.Where(b => b.Price > 50).ToList();
            //
            //IQueryable<Book> booklist2 = _db.Books;                 // aplica el WHERE en bbdd (rapido)
            //var filterBook2 = booklist2.Where(b => b.Price > 50).ToList();


            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;
            //
            //var bookCollection = _db.Books;
            //decimal totalPrice = 0;
            //
            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}
            //
            //var bookList = _db.Books.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}
            //
            //var bookCollection2 = _db.Books;
            //var bookCount1 = bookCollection2.Count();
            //
            //var bookCount2 = _db.Books.Count();
            return RedirectToAction(nameof(Index));
        }
    }
}
