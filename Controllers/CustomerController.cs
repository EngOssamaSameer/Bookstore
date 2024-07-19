using BookStore.Attribute;
using BookStore.DTO;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Sencitve]
    public class CustomerController : ControllerBase
    {
        private readonly IBookService _bookService;
        public CustomerController(IBookService bookService)
        {
            this._bookService = bookService;
        }
        //Get all 
        [HttpGet]
        public ActionResult<List<Book>> Get() 
        {
            return  _bookService.GetAll();
        }

        //Get by id 
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound($"this id : {id} ont found ");
            }
            return Ok(book);
        }

        //creat 
        [HttpPost]
        public ActionResult<BookDTO> Create([FromBody] BookDTO dto)
        {
            Book book = BookToDTO(dto);
            if(_bookService.Create(book) != null)
            {
                return Ok(book);
            }
            return NoContent();
        }

        // Update
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] BookDTO dto , int id) 
        {
            var book = _bookService.Update(id , BookToDTO(dto));
            if (book == null)
            {
                return NotFound("you try to update record not exsting in database");
            }
            return Ok(book);
        }

        //delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_bookService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("this id not found");
        }

        // delete all records in book taable
        [HttpDelete]
        public ActionResult Delete()
        {
            _bookService.DeleteAll();
            return NoContent();
        }


        //Convert DTO to book
        private Book BookToDTO(BookDTO bookDTO)
        {
            Book book = new Book();
            book.Title = bookDTO.Title;
            book.Description = bookDTO.Description;
            book.Author = bookDTO.Author;
            book.Copies = bookDTO.Copies;
            return book;
        }
    }
}
