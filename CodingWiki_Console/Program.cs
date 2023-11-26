// See https://aka.ms/new-console-template for more information

using CodingWiki_DataAccess.Data;
using CodingWiki_DataAccess.Migrations;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");

// 53 - Comprobar bbdd y migraciones traspasadas
//using(ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if(context.Database.GetPendingMigrations().Count() > 0)
//    {
//        context.Database.Migrate();
//    }
//}

//54 - Solicitar todos los libros
//GetAllBooks();

//void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.ToList();
//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title + " - " + book.ISBN);
//    }
//}
//
////55 - Crear un libro
////AddBook();
//
//void AddBook()
//{
//    Book book = new() { ISBN = "000", Title = "Try me", Price = 10.93M, Publisher_id = 1 };
//    using var context = new ApplicationDbContext();
//    context.Books.Add(book);
//    context.SaveChanges();
//}
//
////56- Logging Query -> ApplicationDbContext
//
////57 - Solicitar primer libro
//GetBook();
//
//void GetBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = context.Books.FirstOrDefault();
//        if (book != null) {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }
//    }catch(Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//
////58,59 - Solicitar libro filtrado por publisher y precio
////GetBooksFromPublisherPriceOver(publisherId: 3, price: 30M);
//
//void GetBooksFromPublisherPriceOver(int publisherId, decimal price)
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = context.Books.Where(u => u.Publisher_id == publisherId && u.Price > price);
//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//
////60 - Busca un libro por su key
////FindBookByKey(key: 3);
//
//void FindBookByKey(int key)
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = context.Books.Find(key);
//        Console.WriteLine(book.Title + " - " + book.ISBN);
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//
////61 - Trata de buscar solo un registro
////FindBookByISBN(ISBN: "123812");
//
//void FindBookByISBN(string ISBN)
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = context.Books.SingleOrDefault(u => u.ISBN == ISBN);
//        Console.WriteLine(book.Title + " - " + book.ISBN);
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//
//
////62 - Trata de buscar solo un registro
////FindBookLikeISBN();
//
//void FindBookLikeISBN()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        //var books = context.Books.Where(u => u.ISBN.Contains("12"));
//        var books = context.Books.Where(u => EF.Functions.Like(u.ISBN,"%12%"));
//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//
////64 - Order by
//FindAllBooksOderByTitle();
//
//void FindAllBooksOderByTitle()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = context.Books.Where(u => u.BookDetail1.Weight == "").Where(u => u.ISBN != "").OrderBy(u => u.Title)
//            .ThenByDescending(u => u.ISBN)
//            .ToList();
//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//
////65 - Pagination -> Skip and Take
////FindAllBooksPagination();
//
//void FindAllBooksPagination()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = context.Books.Skip(0).Take(2)
//            .ToList();
//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }
//
//        books = context.Books.Skip(4).Take(2)
//            .ToList();
//        foreach (var book in books)
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN);
//        }
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//
////66 - Update
////UpdateBook();
//
//void UpdateBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = context.Books.Find(9);
//        book.ISBN = "777";
//        context.SaveChanges();
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//
////67 - Delete
//DeleteBook();
//
//void DeleteBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = context.Books.Find(9);
//        context.Remove(book);
//        context.SaveChanges();
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}
//
////68 - Async
//DeleteBookAsync();
//
//async void DeleteBookAsync()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = await context.Books.FindAsync(9);
//        context.Remove(book);
//        await context.SaveChangesAsync();
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}