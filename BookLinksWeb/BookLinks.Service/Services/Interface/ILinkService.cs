using BookLinks.Common.Enums;
using BookLinks.Service.Models;

namespace BookLinks.Service.Services
{
    public interface ILinkService
    {
        Task<List<LinkDto>> GetLinksAsync();
        Task<LinkDto> GetLinkByIdAsync(int? id);
        Task AddLinkAsync(LinkDto book);
        Task DeleteLinkAsync(int? id);
        Task UpdateLinkAsync(LinkDto book);
        Task<IList<LinkDto>> GetFilterLink(string? searchString, List<LinkDto> allLink, LinkOptionsEnum option);
    }
}