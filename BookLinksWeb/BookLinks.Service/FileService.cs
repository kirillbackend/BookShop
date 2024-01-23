using BookLinks.Service.Models;
using FS.Services.Services.Contracts;


namespace FS.Services.Services
{
    public class FileService: IFileService
    {
        public async Task ProcessPhoto(BookDto book)
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
