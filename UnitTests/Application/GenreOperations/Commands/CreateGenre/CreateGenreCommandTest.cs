using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace  Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistGenreTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // arrange {hazırlık}
            var genre = new Genre() { Name = "WhenAlreadyExistGenreTitleIsGiven_InvalidOperationException_ShouldBeReturn" , IsActive = true};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_mapper, _context);
            command.Model = new CreateGenreModel(){Name = genre.Name};

            // act {Çalıştırma}
            FluentActions
            .Invoking(()=>command.Handle())
            // assert {Doğrulama}
            .Should().Throw<InvalidOperationException>();  
        }
        [Fact]
        public void WhenValidInputsGiven_Genre_ShouldBeCreated()
        {
            // arrange {hazırlık}
            CreateGenreCommand command = new CreateGenreCommand(_mapper, _context);
            CreateGenreModel model = new CreateGenreModel()
            {
                Name = "demo"
            };
            command.Model = model;
            
            // act {Çalıştırma}
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // assert {Doğrulama}
            var genre = _context.Genres.SingleOrDefault(b=>b.Name == model.Name);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);
        }
    }
}    