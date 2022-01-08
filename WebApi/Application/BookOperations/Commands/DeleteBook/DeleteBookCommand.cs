using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.DeleteBook{
    public class DeleteBookCommand{
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            var book = _dbContext.Books.FirstOrDefault(x => x.ID == BookId);
            if (book is null){
                throw new InvalidOperationException("Silmeye calistiginiz kitap veritabaninda mevcut değil!");
            }
            
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

    }

}