using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre{
    public class UpdateGenreCommand {
        public UpdateGenreModel Model { get; set; }
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateGenreCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle() {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == GenreId);
            if (genre is null){
                throw new InvalidOperationException("Kitap türü bulunamadı!");
            }
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId)){
                throw new InvalidOperationException("Aynı isimli kitap türü zaten var!");
            }

            genre.Name = Model.Name.Trim() == default ? genre.Name : Model.Name;
            genre.IsActive = Model.isActive == default ? genre.IsActive : Model.isActive;

            _context.SaveChanges();
        }
        
    }
    public class UpdateGenreModel {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}