using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }

        public GetGenreDetailQuery(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public GenreViewModel Handle(){
            var genre = _context.Genres.FirstOrDefault(x => x.Id == GenreId && x.IsActive);
            if (genre == null){
                Console.WriteLine(genre);
                throw new InvalidOperationException("Kitap Türü Bulunamadı.");
            }
            return _mapper.Map<GenreViewModel>(genre);
        }
    }
    public class GenreViewModel{
         public string Name { get; set; }
    }
}