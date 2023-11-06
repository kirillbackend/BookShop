using BookLinks.Repositories.Models;

namespace FS.Services.Services.Contracts
{
    public interface IFileService
    {
        Task ProcessPhoto(Book book);
    }
}
