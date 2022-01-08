using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.UpdateCommand
{
    public class UpdateBookCommandTests: IClassFixture<CommonTestFixture>
    {
        
        private readonly BookStoreDbContext _context;
        
        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;

        }

        [Theory]
        [InlineData("Deneme2",3,2)]
        public void WhenValidInputsAreGiven_Book_ShouldBeUpdated(string title, int authorId, int genreId)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = 3; 

            command.Model = new UpdateBookModel();
            command.Model.Title = title;
            command.Model.GenreID = genreId;
            command.Model.AuthorId = authorId;
            

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(book => book.Title == command.Model.Title );
            book.Should().NotBeNull();
            book.GenreID.Should().Be(command.Model.GenreID);
            book.Title.Should().Be(command.Model.Title);
            book.AuthorId.Should().Be(command.Model.AuthorId);
   
        } 
    }
}