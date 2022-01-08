using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
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
        }
    }
}