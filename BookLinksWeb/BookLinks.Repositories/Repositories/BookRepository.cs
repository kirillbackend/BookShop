using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookLinks.Repositories.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetBookByIdAsync(int? id)
        {
            if (id != null)
            {
                var books = await _context.Books.FirstAsync(i => i.Id == id);
                return books;
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBookAsync(int? id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(i => i.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(book));
            }
        }
    }
}
