using BookLinks.Common.Enums;
using BookLinks.Repositories.Models;

namespace BookLinks.Repositories.Repositories.Interface
{
    public interface ILinkService
    {
        Task<List<Link>> GetLinksAsync();
        Task<Link> GetLinkByIdAsync(int? id);
        Task<Link> AddLinkAsync(Link book);
        Task DeleteLinkAsync(int? id);
        Task UpdateLinkAsync(Link book);
        Task<IList<Link>> GetFilterLink(string? searchString, List<Link> allLink, LinkOptionsEnum option);
    }
}