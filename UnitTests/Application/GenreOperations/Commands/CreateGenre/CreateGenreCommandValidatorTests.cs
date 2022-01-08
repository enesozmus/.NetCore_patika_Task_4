using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using FluentAssertions;
using Xunit;
using TestSetup;
using WebApi.Application.GenreOperations.Commands.CreateGenre;

namespace Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {}
}