using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBook;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;

namespace WebApi.Common{
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            // for book
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FirstName + " "+ src.Author.LastName));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FirstName + " "+ src.Author.LastName));

            // for genre
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            // for author
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<CreateAuthorModel, Author>();
        }
    }
}