using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookLinks.Repositories.Models;

namespace BookLinks.Web.Data
{
    public class BookLinksWebContext : DbContext
    {
        public BookLinksWebContext (DbContextOptions<BookLinksWebContext> options)
            : base(options)
        {
        }

        public DbSet<BookLinks.Repositories.Models.Book> Book { get; set; } = default!;
    }
}
