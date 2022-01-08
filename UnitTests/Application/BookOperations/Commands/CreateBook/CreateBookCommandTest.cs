using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using FluentAssertions;
using Xunit;
using TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTest : IClassFixture<CommonTestFixture>
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTest(CommonTestFixture TestFixture)
        {
            _mapper = TestFixture.Mapper;
            _context = TestFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeThrown()
        {
            // arrange → → Hazırlık
            var book = new Book()
            {
                Title = "test_WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeThrown",
                PageCount = 100,
                GenreID = 1,
                AuthorId = 1,
                PublishDate = new DateTime(2000, 02, 02)
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand commands = new CreateBookCommand(_context, _mapper);
            commands.Model = new CreateBookModel(){Title = book.Title};

            // act → → Calıştırma

            FluentActions
                .Invoking(() => commands.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Eklemeye calistiginiz kitap veritabaninda zaten mevcut!");
        }
        
        [Fact]
        public void WhenValidInputsGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateBookCommand command = new(_context, _mapper);
            CreateBookModel model = new CreateBookModel()
            {
                Title = "Lotr",
                PageCount = 99,
                PublishDate = System.DateTime.Now.Date.AddYears(-10),
                GenreId = 1,
                AuthorId = 1,
            };
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();

            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreID.Should().Be(model.GenreId);
            book.AuthorId.Should().Be(model.AuthorId);
        }
    }
}