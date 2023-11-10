using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;

namespace BookLinks.Service.Services.Interface
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int? id);
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(int? id);
        Task UpdateBookAsync(Book book);
        Task<IList<Book>> GetFilterBook(string? SearchString, List<Book> allBooks, BookOptiosEnum Option);
    }
}