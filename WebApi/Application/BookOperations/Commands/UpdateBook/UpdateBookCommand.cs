using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Commands.UpdateBook{
    public class UpdateBookCommand{
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookModel Model { get; set; }
        public int BookId { get; set; }
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            Book book = _dbContext.Books.SingleOrDefault(book => book.ID == BookId);

            if (book is null){
                throw new InvalidOperationException("Guncellemeye calistiginiz kitap veritabaninda mevcut değil!");
            }

            book.GenreID = Model.GenreID == default ? book.GenreID : Model.GenreID;
            book.Title = Model.Title == default ? book.Title : Model.Title;
            book.PublishDate = Model.PublishDate == default ? book.PublishDate : Model.PublishDate;
            book.PageCount = Model.PageCount == default ? book.PageCount : Model.PageCount;
            book.AuthorId = Model.AuthorId == default ? book.AuthorId : Model.AuthorId;

            _dbContext.SaveChanges();
        }

    }
    public class UpdateBookModel{
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreID { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}