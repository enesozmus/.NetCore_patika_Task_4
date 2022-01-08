using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.DBOperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests: IClassFixture<CommonTestFixture>
    {}
}