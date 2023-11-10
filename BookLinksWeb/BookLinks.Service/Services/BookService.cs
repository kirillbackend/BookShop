using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Services.Interface;
using FS.Services.Services.Contracts;

namespace BookLinks.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IFileService _fileService;

        public BookService(IBookRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
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

        public async Task AddBookAsync(Book book)
        {
            if (book != null)
            {
                await _fileService.ProcessPhoto(book);
                book.Created = DateTime.Now;
                await _repository.AddBookAsync(book);
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
                await _fileService.ProcessPhoto(book);
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
            if ((Option == BookOptiosEnum.id && !int.TryParse(SearchString, out parsedId))
                || (Option == BookOptiosEnum.Rating && !int.TryParse(SearchString, out parsedId)))
            {
                throw new ArgumentException(nameof(Option));
            }
            else
            {
                var books = new List<Book>();
                var filters = new Dictionary<BookOptiosEnum, Func<IList<Book>, IList<Book>>>()
                {
                    {BookOptiosEnum.id, (list) => list = list.Where(l => l.Id == parsedId).ToList()},
                    {BookOptiosEnum.Name, (list) => list = list.Where(l => l.Name.ToLower().Contains(SearchString.ToLower())).ToList()},
                    {BookOptiosEnum.Author, (list) => list = list.Where(l => l.Author.ToLower().Contains(SearchString.ToLower())).ToList()},
                    {BookOptiosEnum.Rating, (list) => list = list.Where(l => l.Rating == parsedId).ToList()}
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
