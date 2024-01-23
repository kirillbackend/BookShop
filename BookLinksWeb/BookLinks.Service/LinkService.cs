using AutoMapper;
using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Service.Models;

namespace BookLinks.Service.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _repository;
        private readonly IMapper _mapper;

        public LinkService(ILinkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LinkDto>> GetLinksAsync()
        {
            try
            {
                var links = await _repository.GetLinksAsync();
                var linksDto = _mapper.Map<List<LinkDto>>(links);
                return linksDto;
            }
            catch (Exception)
            {

                throw new ArgumentNullException();
            }
        }

        public async Task<LinkDto> GetLinkByIdAsync(int? id)
        {
            if (id != null)
            {
                var link = await _repository.GetLinkByIdAsync(id);
                var linkDto = _mapper.Map<LinkDto>(link);
                return linkDto;
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
        }

        public async Task AddLinkAsync(LinkDto linkDto)
        {
            if (linkDto != null)
            {
                var link = _mapper.Map<Link>(linkDto);
                await _repository.AddLinkAsync(link);
            }
            else
            {
                throw new ArgumentException(nameof(linkDto));
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

        public async Task UpdateLinkAsync(LinkDto linkDto)
        {
            if (linkDto != null)
            {
                var link = _mapper.Map<Link>(linkDto);
                await _repository.UpdateLinkAsync(link);
            }
            else
            {
                throw new ArgumentNullException(nameof(linkDto));
            }
        }

        public async Task<IList<LinkDto>> GetFilterLink(string? searchString, List<LinkDto> allLink, LinkOptionsEnum option)
        {
            int parsedId = -1;
            if ((option == LinkOptionsEnum.id && !int.TryParse(searchString, out parsedId))
                || (option == LinkOptionsEnum.BookId && !int.TryParse(searchString, out parsedId)))
            {
                throw new ArgumentException(nameof(option));
            }
            else
            {
                var books = new List<LinkDto>();
                var filters = new Dictionary<LinkOptionsEnum, Func<IList<LinkDto>, IList<LinkDto>>>()
                {
                    {LinkOptionsEnum.id, (list) => list = list.Where(l => l.Id == parsedId).ToList()},
                    {LinkOptionsEnum.Name, (list) => list = list.Where(l => l.Book.Name.ToLower().Contains(searchString.ToLower())).ToList()},
                    {LinkOptionsEnum.Author, (list) => list = list.Where(l => l.Book.Author.ToLower().Contains(searchString.ToLower())).ToList()},
                    {LinkOptionsEnum.BookId, (list) => list = list.Where(l => l.BookId == parsedId).ToList()}
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
