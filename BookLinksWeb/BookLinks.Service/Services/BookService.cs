using BookLinks.Common.Enums;
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
                book.Created = DateTime.Now;
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
                book.Update = DateTime.Now;
                await _repository.UpdateBookAsync(book);
            }
            else
            {
                throw new ArgumentNullException(nameof(book));
            }
        }

        public async Task<IList<Book>> GetFilterBook(string? SearchString, List<Book> allBooks, BookOptiosEnum Option)
        {
            int parsedId = -1;
            if (Option == BookOptiosEnum.id && !int.TryParse(SearchString, out parsedId))
            {
                throw new ArgumentException(nameof(Option));
            }
            else
            {
                var books = new List<Book>();
                var filters = new Dictionary<BookOptiosEnum, Func<IList<Book>, IList<Book>>>()
                {
                    {BookOptiosEnum.id, (list) => list = list.Where(l => l.Id == parsedId).ToList()},
                    {BookOptiosEnum.Name, (list) => list = list.Where(l => l.Name.Contains(SearchString)).ToList()},
                    {BookOptiosEnum.Author, (list) => list = list.Where(l => l.Author.Contains(SearchString)).ToList()}
                };

                if (filters.ContainsKey(Option))
                {
                    books = filters[Option](allBooks).ToList();
                }

                return books;
            }
        }
    }
}
