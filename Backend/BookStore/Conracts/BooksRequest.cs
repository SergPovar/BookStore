namespace BookStore.Conracts
{
    public record BooksRequest(
         Guid Id,
         string Title,
         string Description,
         decimal Price);
}
