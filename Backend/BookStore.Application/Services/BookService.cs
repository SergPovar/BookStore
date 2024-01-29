using BookStore.Core.Abstraction;
using BookStore.Core.Models;

namespace BookStore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _booksRepository;
        public BookService(IBooksRepository booksRepository )
        {
            _booksRepository = booksRepository;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            return await _booksRepository.GetAll();
        }
        public async Task<Guid> CreateBook(Book book)
        {
            return await _booksRepository.Create( book );
        }
        public async Task<Guid> UpdateBook(Guid id, string title, string descpription, decimal price)
        {
            return await _booksRepository.Update(id, title, descpription, price);
        }
        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _booksRepository.Delete(id);
        }

    }
}
