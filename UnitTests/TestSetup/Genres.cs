using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
            new Genre
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
        }
    }
}