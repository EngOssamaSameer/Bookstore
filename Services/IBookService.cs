using BookStore.Models;

namespace BookStore.Services
{
    public interface IBookService
    {
        public List<Book> GetAll();
        public Book GetById(int id);

        public Book Create(Book book);

        public Book Update(int Id,Book book);

        public bool Delete(int id);

        public void DeleteAll();

    }
}
