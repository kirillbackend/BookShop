using BookLinks.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookLinks.Repositories
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Link> Links { get; set; }

        public DbSet<BookOrder> BookOrders { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasKey(m => m.Id);
            builder.Entity<Order>().HasKey(m => m.Id);
            builder.Entity<BookOrder>(entity =>
            {
                entity.HasKey(bo => new { bo.OrderId, bo.BookId });

                entity.HasOne(bo => bo.Book)
                      .WithMany(b => b.BookOrders)
                      .HasForeignKey(bo => bo.BookId)
                      .OnDelete(DeleteBehavior.Restrict); // Restrict or Cascade

                entity.HasOne(bo => bo.Order)
                      .WithMany(o => o.BookOrders)
                      .HasForeignKey(bo => bo.OrderId)
                      .OnDelete(DeleteBehavior.Restrict); // Restrict or Cascade
            });
        }
    }
}
