using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle() {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == AuthorId);
            if (author is null){
                throw new InvalidOperationException("Guncellemeye calistiginiz yazar veritabaninda mevcut değil!");
            }
            
            Model.FirstName = Model.FirstName[0].ToString().ToUpper() + Model.FirstName.Substring(1, Model.FirstName.Length - 1).ToLower();
            Model.LastName = Model.LastName[0].ToString().ToUpper() + Model.LastName.Substring(1, Model.LastName.Length - 1).ToLower();

            if (_context.Authors.Any(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName && x.Id != AuthorId)){
                throw new InvalidOperationException("veritabaninda aynı isimde yazar zaten mevcut!");
            }


            author.FirstName = Model.FirstName == default ? author.FirstName : Model.FirstName;
            author.LastName = Model.LastName == default ? author.LastName : Model.LastName;
            author.BirthDate = Model.BirthDate == default ? author.BirthDate : Model.BirthDate;

            _context.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}