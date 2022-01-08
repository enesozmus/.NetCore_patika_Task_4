using AutoMapper;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_mapper, _context);
            List<GenresViewModel> genres = query.Handle();
            return Ok(genres);
        }
        [HttpGet("{id}")]
        public ActionResult GetGenreById(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_mapper, _context);
            query.GenreId = id;
            GenreViewModel genre = query.Handle();
            return Ok(genre);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateGenre([FromBody] UpdateGenreModel model, int id){
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);
            command.Model = model;
            command.GenreId = id;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Genre başarıyla guncellendi!");
        }
        [HttpPost]
        public ActionResult CreateGenre([FromBody] CreateGenreModel model) {
            CreateGenreCommand command = new CreateGenreCommand(_mapper, _context);
            command.Model = model;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Genre başarıyla eklendi!");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteGenre(int id){
            DeleteGenreCommand command = new DeleteGenreCommand(_mapper, _context);
            command.GenreId = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Genre başarıyla silindi!");
        }

    }
}