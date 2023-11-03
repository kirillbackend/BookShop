using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BookLinks.Repositories.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly DataContext _context;

        public LinkRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Link>> GetLinksAsync()
        {
            var link = await _context.Links.ToListAsync();
            return link;
        }

        public async Task<Link> GetLinkByIdAsync(int? id)
        {
            if (id != null)
            {
                var links = await _context.Links.FirstAsync(i => i.Id == id);
                return links;
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task<Link> AddLinkAsync(Link link)
        {
            await _context.Links.AddAsync(link);
            await _context.SaveChangesAsync();
            return link;
        }

        public async Task DeleteLinkAsync(int? id)
        {
            var link = await _context.Links.FirstOrDefaultAsync(i => i.Id == id);
            if (link != null)
            {
                _context.Links.Remove(link);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException(nameof(link));
            }
        }

        public async Task UpdateLinkAsync(Link link)
        {
            _context.Links.Update(link);
            await _context.SaveChangesAsync();
        }
    }
}
