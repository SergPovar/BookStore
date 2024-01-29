using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace BookStore.Conracts
{
    public record BooksResponse(
        Guid Id,
        string Title,
        string Description,
        decimal Price);
}
