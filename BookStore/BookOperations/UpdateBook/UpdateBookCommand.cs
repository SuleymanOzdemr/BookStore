using BookStore.DBOperations;
using System;
using System.Linq;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        //public UpdateBookModel Model { get; set; }
        //public int MyProperty { get; set; }
        //private readonly BookStoreDbContext _dbContext;

        //public UpdateBookCommand(BookStoreDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public void Handle()
        //{
        //    var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);

        //    if (book is null)
        //        throw new InvalidOperationException("Kitap zaten Mevcut");

        //    book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        //    book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
        //    book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
        //    book.Title = Model.Title != default ? Model.Title : book.Title;
        //}
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public int GenreId { get; set; }
    }
}
