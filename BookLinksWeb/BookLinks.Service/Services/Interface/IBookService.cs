using BookLinks.Common.Enums;
using BookLinks.Service.Models;

namespace BookLinks.Service.Services.Interface
{
    public interface IBookService
    {
        Task<List<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookByIdAsync(int? id);
        Task AddBookAsync(BookDto book);
        Task DeleteBookAsync(int? id);
        Task UpdateBookAsync(BookDto book);
        Task<IList<BookDto>> GetFilterBook(string? SearchString, List<BookDto> allBooks, BookOptiosEnum Option);
    }
}