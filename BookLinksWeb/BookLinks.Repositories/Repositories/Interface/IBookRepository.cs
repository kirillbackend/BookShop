using BookLinks.Repositories.Models;

namespace BookLinks.Repositories.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int? id);
        Task<Book> AddBookAsync(Book book);
        Task DeleteBookAsync(int? id);
        Task UpdateBookAsync(Book book);
    }
}