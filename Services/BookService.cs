using BookStore.Context;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _ctx;

        // Constrctor
        public BookService(AppDbContext ctx)
        {
            this._ctx = ctx;
        }

        // Create new Book
        public Book Create(Book book)
        {
            _ctx.TbBooks.Add(book);
            _ctx.SaveChanges();
            return book;
        }

        // Delete an exsting book if not found book return flase
        public bool Delete(int id)
        {
            var book = _ctx.TbBooks.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _ctx.TbBooks.Remove(book);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }

        //Delete all records
        public void DeleteAll()
        {
            var all = _ctx.TbBooks.ToList();
            _ctx.TbBooks.RemoveRange(all);
            _ctx.SaveChanges();
        }

        //return all recordes
        public List<Book> GetAll()
        {
            return _ctx.TbBooks.ToList();
        }

        // return one book by id
        public Book GetById(int id)
        {
            var book = _ctx.TbBooks.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                return book;
            }
            return new Book();

        }

        // update exsting book
        public Book Update(int Id, Book book)
        {
            var bookInDatabase = _ctx.TbBooks.FirstOrDefault(a=>a.Id == Id);
            if (bookInDatabase != null)
            {
                bookInDatabase.Description = book.Description;
                bookInDatabase.Title = book.Title;
                bookInDatabase.Author = book.Author;
                bookInDatabase.Copies = book.Copies;

                _ctx.TbBooks.Update(bookInDatabase);
                _ctx.SaveChanges();
                return book;
            }
            return new Book();
        }
    }
}
