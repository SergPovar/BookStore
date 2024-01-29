﻿using BookStore.Core.Models;

namespace BookStore.Core.Abstraction
{
    public interface IBookService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetAllBooks();
        Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
    }
}

