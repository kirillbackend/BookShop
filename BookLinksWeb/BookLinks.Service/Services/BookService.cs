using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Services.Interface;

namespace BookLinks.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                var books = await _repository.GetBooksAsync();
                return books;
            }
            catch (Exception)
            {

                throw new ArgumentNullException();
            }
        }

        public async Task<Book> GetBookByIdAsync(int? id)
        {
            if (id != null)
            {
                var books = await _repository.GetBookByIdAsync(id);
                return books;
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            if (book != null)
            {
                await _repository.AddBookAsync(book);
                return book;
            }
            else
            {
                throw new ArgumentException(nameof(book));
            }
        }

        public async Task DeleteBookAsync(int? id)
        {
            if (id != null)
            {
                await _repository.DeleteBookAsync(id);
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            if (book != null)
            {
                await _repository.UpdateBookAsync(book);
            }
            else
            {
                throw new ArgumentNullException(nameof(book));
            }
        }
    }
}
