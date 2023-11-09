using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;

namespace BookLinks.Repositories.Repositories
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _repository;

        public LinkService(ILinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Link>> GetLinksAsync()
        {
            try
            {
                var links = await _repository.GetLinksAsync();
                return links;
            }
            catch (Exception)
            {

                throw new ArgumentNullException();
            }
        }

        public async Task<Link> GetLinkByIdAsync(int? id)
        {
            if (id != null)
            {
                var link = await _repository.GetLinkByIdAsync(id);
                return link;
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task<Link> AddLinkAsync(Link link)
        {
            if (link != null)
            {
                await _repository.AddLinkAsync(link);
                return link;
            }
            else
            {
                throw new ArgumentException(nameof(link));
            }
        }

        public async Task DeleteLinkAsync(int? id)
        {
            if (id != null)
            {
                await _repository.DeleteLinkAsync(id);
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task UpdateLinkAsync(Link link)
        {
            if (link != null)
            {
                await _repository.UpdateLinkAsync(link);
            }
            else
            {
                throw new ArgumentNullException(nameof(link));
            }
        }

        public async Task<IList<Link>> GetFilterLink(string? searchString, List<Link> allLink, LinkOptiosEnum option)
        {
            int parsedId = -1;
            if ((option == LinkOptiosEnum.id && !int.TryParse(searchString, out parsedId))
                || (option == LinkOptiosEnum.BookId && !int.TryParse(searchString, out parsedId)))
            {
                throw new ArgumentException(nameof(option));
            }
            else
            {
                var books = new List<Link>();
                var filters = new Dictionary<LinkOptiosEnum, Func<IList<Link>, IList<Link>>>()
                {
                    {LinkOptiosEnum.id, (list) => list = list.Where(l => l.Id == parsedId).ToList()},
                    {LinkOptiosEnum.Name, (list) => list = list.Where(l => l.Book.Name.ToLower().Contains(searchString.ToLower())).ToList()},
                    {LinkOptiosEnum.Author, (list) => list = list.Where(l => l.Book.Author.ToLower().Contains(searchString.ToLower())).ToList()},
                    {LinkOptiosEnum.BookId, (list) => list = list.Where(l => l.BookId == parsedId).ToList()}
                };

                if (filters.ContainsKey(option))
                {
                    books = filters[option](allLink).ToList();
                }

                return books;
            }
        }
    }
}
