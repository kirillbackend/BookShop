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
    }
}
