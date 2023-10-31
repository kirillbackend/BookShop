using BookLinks.Common.Enums;
using BookLinks.Service.Services.Interface;

namespace BookLinks.Service.Services
{
    public class BookService : IBookService
    {
        public Array GetEnums()
        {
            var result = Enum.GetValues(typeof(TestEnums));
            return result;
        }
    }
}
