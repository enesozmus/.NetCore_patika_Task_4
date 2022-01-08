using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any() || context.Genres.Any() || context.Authors.Any())
                {
                    return;
                }

                // ***** Entities ***** //
                context.Authors.AddRange(new Author
                {
                    FirstName = "Charles",
                    LastName = "Dickens",
                    BirthDate = new DateTime(1812, 02, 07)    //1
                }, new Author
                {
                    FirstName = "Leo",
                    LastName = "Tolstoy",
                    BirthDate = new DateTime(1828, 09, 09)   //2
                },
                new Author
                {
                    FirstName = "Gustave",
                    LastName = "Flaubert",
                    BirthDate = new DateTime(1821, 12, 12)  //3
                },
                new Author
                {
                    FirstName = "Dante",
                    LastName = "Alighieri",
                    BirthDate = new DateTime(1265, 05, 14)  //4
                },
                new Author
                {
                    FirstName = "George",
                    LastName = "Orwell",
                    BirthDate = new DateTime(1903, 05, 25)  //5
                },
                new Author
                {
                    FirstName = "Fyodor",
                    LastName = "Dostoevsky",
                    BirthDate = new DateTime(1821, 12, 11)  //6
                },
                new Author
                {
                    FirstName = "Emily",
                    LastName = "Brontë",
                    BirthDate = new DateTime(1818, 06, 30)  //7
                }
                );

                // ***** Entities ***** //
                context.Genres.AddRange(new Genre                   
                {
                    Name = "First Genre"
                },
                new Genre
                {
                    Name = "Second Genre"
                },
                new Genre
                {
                    Name = "Novel"
                });

                // ***** Entities ***** //
                context.Books.AddRange(
                    new Book
                    {
                        Title = "A Tale of Two Cities",
                        GenreID = 3,
                        AuthorId = 1,
                        PageCount = 489,
                        PublishDate = new DateTime(1859, 05, 05),

                    },
                    new Book
                    {
                        Title = "Anna Karenina",
                        GenreID = 3,
                        AuthorId = 2,
                        PageCount = 964,
                        PublishDate = new DateTime(1877, 05, 05),

                    },
                    new Book
                    {
                        Title = "Madame Bovary",
                        GenreID = 2,
                        AuthorId = 3,
                        PageCount = 329,
                        PublishDate = new DateTime(1856, 05, 05)

                    },
                    new Book
                    {
                        Title = "Inferno",
                        GenreID = 3,
                        AuthorId = 4,
                        PageCount = 490,
                        PublishDate = new DateTime(1320, 05, 05),

                    },
                    new Book
                    {
                        Title = "1984",
                        GenreID = 1,
                        AuthorId = 5,
                        PageCount = 298,
                        PublishDate = new DateTime(1949, 05, 05),

                    },
                    new Book
                    {
                        Title = "The Brothers Karamazov",
                        GenreID = 1,
                        AuthorId = 6,
                        PageCount = 796,
                        PublishDate = new DateTime(1879, 05, 05),

                    },
                    new Book
                    {
                        Title = "Wuthering Heights",
                        GenreID = 2,
                        AuthorId = 7,
                        PageCount = 464,
                        PublishDate = new DateTime(1847, 05, 05),

                    });
                context.SaveChanges();
            }
        }
    }
}