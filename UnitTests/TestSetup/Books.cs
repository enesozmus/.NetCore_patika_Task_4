using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
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
                        PublishDate = new DateTime(1856, 05, 05),

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
        }
    }
}