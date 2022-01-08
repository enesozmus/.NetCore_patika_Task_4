using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DBOperations;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;

        [Theory]
        [InlineData("a")]
        [InlineData("b")]
        public void WhenInvalidInput_Validator_ShouldBeReturnErrors(string genreName)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);
            UpdateGenreModel model = new UpdateGenreModel() { Name = genreName };
            command.Model = model;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
