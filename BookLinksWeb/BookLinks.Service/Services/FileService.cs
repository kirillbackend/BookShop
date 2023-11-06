using BookLinks.Repositories.Models;
using FS.Services.Services.Contracts;
using System.Text.RegularExpressions;


namespace FS.Services.Services
{
    public class FileService: IFileService
    {
        public async Task ProcessPhoto(Book book)
        {
            try
            {
                var fullPath = "C:\\Work\\BookShop\\BookLinksWeb\\BookLinks.Web\\wwwroot\\img";
                book.ImageContent = Path.Combine(fullPath, book.OriginalFileName);
                var photoUrl = $"/img/{book.OriginalFileName}";
                book.ImageContent = photoUrl;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
