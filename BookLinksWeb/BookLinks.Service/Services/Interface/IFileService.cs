using BookLinks.Service.Models;

namespace FS.Services.Services.Contracts
{
    public interface IFileService
    {
        Task ProcessPhoto(BookDto book);
    }
}
