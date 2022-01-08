using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }              // Entities
        public DbSet<Genre> Genres { get; set; }            // Entities
        public DbSet<Author> Authors { get; set; }          // Entities
    }
}