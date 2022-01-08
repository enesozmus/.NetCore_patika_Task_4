using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations;
using WebApi.Application.BookOperations.Queries.GetBook;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Queries
{
    public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenBookIdIsValid_ParticularBook_ShouldBeReturned()
        {
            GetBookQuery query = new GetBookQuery(_context, _mapper);
            query.BookId = 2;

            BookViewModel book = new BookViewModel()
            {
                Title = "A Tale of Two Cities",
                Genre = "First Genre",
                Author = "Charles Dickens",
                PageCount = 489,
            };

            FluentActions.Invoking(() => query.Handle()).Invoke();
            var model = query.Handle();
            model.Should().NotBeNull();
            model.PageCount.Should().Be(book.PageCount);
            model.Genre.Should().Be(book.Genre);
            book.Title.Should().Be(model.Title);
            model.Author.Should().Be(book.Author);
        }
    }
}