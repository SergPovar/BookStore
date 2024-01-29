using BookStore.Conracts;
using BookStore.Core.Abstraction;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _bookService.GetAllBooks();

            var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest booksRequest)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(),
                booksRequest.Title,
                booksRequest.Description,
                booksRequest.Price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            var bookId = await _bookService.CreateBook(book);
            return Ok(bookId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequest booksRequest)
        {
            var bookId = await _bookService.UpdateBook(id, booksRequest.Title, booksRequest.Description, booksRequest.Price);
            return Ok(bookId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            return Ok(await _bookService.DeleteBook(id));
        }
    }
}
