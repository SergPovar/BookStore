﻿using BookStore.Core.Models;

namespace BookStore.Core.Abstraction
{
    public interface IBooksRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> GetAll();
        Task<Guid> Update(Guid id, string title, string description, decimal price);
    }
}