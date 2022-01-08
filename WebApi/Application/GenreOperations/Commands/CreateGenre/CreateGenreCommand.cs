using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;
        public CreateGenreModel Model { get; set; }
        public CreateGenreCommand(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle() {
            var genre = _context.Genres.FirstOrDefault(x => x.Name == Model.Name);
            if (genre is not null){
                throw new InvalidOperationException("Eklemek istediğiniz tür zaten mevcut!");
            }
            _context.Genres.Add(_mapper.Map<Genre>(Model));
            _context.SaveChanges();
        }
    }
    public class CreateGenreModel{
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}