using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;
        public int GenreId {get;set;}
        public DeleteGenreCommand(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle() {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == GenreId);
            if (genre is null){
                throw new InvalidOperationException("Silmeye çalıştığınız tür zaten yok!");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();

        }
    }
}