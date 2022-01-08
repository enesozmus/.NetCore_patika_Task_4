using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public DeleteAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle() {
            var author = _context.Authors.FirstOrDefault(x => x.Id == AuthorId);
            if (author is null){
                throw new InvalidOperationException("Silmeye calistiginiz yazar veritabaninda mevcut değil!");
            }
            if (_context.Books.Any(x => x.AuthorId == AuthorId)){
                throw new InvalidOperationException("Yazarin yayinda kitabi var silinemez.");   // → istemler arasında
            }
            
            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}