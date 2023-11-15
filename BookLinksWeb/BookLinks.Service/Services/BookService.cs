using AutoMapper;
using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Models;
using BookLinks.Service.Services.Interface;
using FS.Services.Services.Contracts;

namespace BookLinks.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IFileService fileService, IMapper mapper)
        {
            _repository = repository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetBooksAsync()
        {
            try
            {
                var books = await _repository.GetBooksAsync();
                var booksDto = _mapper.Map<List<BookDto>>(books);
                return booksDto;
            }
            catch (Exception)
            {

                throw new ArgumentNullException();
            }
        }

        public async Task<BookDto> GetBookByIdAsync(int? id)
        {
            if (id != null)
            {
                var book = await _repository.GetBookByIdAsync(id);
                var bookDto = _mapper.Map<BookDto>(book);
                return bookDto;
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task AddBookAsync(BookDto bookDto)
        {
            if (bookDto != null)
            {
                await _fileService.ProcessPhoto(bookDto);
                var book = _mapper.Map<Book>(bookDto);
                bookDto.Created = DateTime.Now;
                await _repository.AddBookAsync(book);
            }
            else
            {
                throw new ArgumentException(nameof(bookDto));
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

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            if (bookDto != null)
            {
                await _fileService.ProcessPhoto(bookDto);
                var book = _mapper.Map<Book>(bookDto);
                book.Update = DateTime.Now;
                await _repository.UpdateBookAsync(book);
            }
            else
            {
                throw new ArgumentNullException(nameof(bookDto));
            }
        }

        public async Task<IList<BookDto>> GetFilterBook(string? SearchString, List<BookDto> allBooks, BookOptiosEnum Option)
        {
            int parsedId = -1;
            if ((Option == BookOptiosEnum.id && !int.TryParse(SearchString, out parsedId))
                || (Option == BookOptiosEnum.Rating && !int.TryParse(SearchString, out parsedId)))
            {
                throw new ArgumentException(nameof(Option));
            }
            else
            {
                var books = new List<BookDto>();
                var filters = new Dictionary<BookOptiosEnum, Func<IList<BookDto>, IList<BookDto>>>()
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
