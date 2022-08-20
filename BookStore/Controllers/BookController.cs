using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.GetDetail;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using BookStore.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {
        private readonly BookStoreDbContext _contex;

        public BookController(BookStoreDbContext contex)
        {
            _contex = contex;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new GetBookQuery(_contex);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_contex);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_contex);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
           UpdateBookCommand command = new UpdateBookCommand(_contex);
            try
            {
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookQuery query = new DeleteBookQuery(_contex);
                query.BookId = id; 
                query.Handle();
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}

