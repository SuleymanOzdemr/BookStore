using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookQuery
    {
        public DeleteBookModel model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public DeleteBookQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
               throw new InvalidOperationException("Silinecek kitap bulunamadı.");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
    public class DeleteBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public int GenreId { get; set; }
    }
}
