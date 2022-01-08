using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.BookOperations.Queries.GetBook{
    public class GetBookQuery{
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookViewModel Handle(){
            Book book = _dbContext.Books.Include(x => x.Genre).Include(x => x.Author).Where(x => x.ID == BookId).FirstOrDefault();
            if (book is null){
                throw new InvalidOperationException("Kitap bulunamadi!");
            }
            BookViewModel vm = _mapper.Map<BookViewModel>(book);
            return vm;
        }
        
    }
    public class BookViewModel{
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string  Genre { get; set; }
        public string Author {get;set;}
    }
}