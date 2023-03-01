using System.ComponentModel.Design;
using System.Data;
using System.Threading;
using System.Net;
 using Microsoft.AspNetCore.Mvc;
 using System;
 using System.Collections.Generic;
 using WebApi.DBOperations;
using System.Linq;
 using WebApi.BookOperations.GetBooks;
  using WebApi.BookOperations.CreateBook;
  using static WebApi.BookOperations.CreateBook.CreateBookCommand;
  using WebApi.BookOperations.GetBookDetail;
  using WebApi.BookOperations.UpdateBook;
  using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;
  using WebApi.BookOperations.DeleteBook;
  using static WebApi.BookOperations.DeleteBook.DeleteBookCommand;
 
  
 



namespace WebApi.AddControllers{
     
     [ApiController]
      [Route("[controller]s")]

     public class BookController : ControllerBase
     {
        private readonly BookStoreDbContext _context;

        public BookController (BookStoreDbContext context)
        {
          _context = context;

        }


      

         [HttpGet]

         public IActionResult GetBooks()
         {
              GetBooksQuery query = new GetBooksQuery(_context);
             var result = query.Handle();
              return Ok(result);
         }



         [HttpGet ("{id}")] 
          // Route ile
        public IActionResult GetById(int id )
        {
          BookDetailViewModel result;
          try
          {
            GetBooksDetailQuery query = new GetBooksDetailQuery (_context);
            query.BookId = id;
            result = query.Handle();
          }
          catch (Exception ex)
          {
            
            return BadRequest(ex.Message);
          }

          return Ok(result);
           
        }

         
        // query ile (sadece bir get kabul ediyor o nedenle yoruma aldım)
        //   [HttpGet] 
        // public Book Get([FromQuery] string id )
        // {
        //     var book2 = BookList.Where(x => x.Id ==  Convert.ToInt32(id)).SingleOrDefault();
        //     return book2;
        // }



       [HttpPost]

       public IActionResult AddBook ([FromBody] CreateBookModel newBook )

       {
   CreateBookCommand command = new CreateBookCommand (_context);
        try
        {
          command.Model = newBook;
        command.Handle();
        }
        catch (Exception ex)
        {
          
          return BadRequest(ex.Message);
        }


        
        

            return Ok();    

       }






       [HttpPut("{id}")]

       public IActionResult UpdateBook(int id , [FromBody] UpdateBookModel updateBook)
       {
        try
        {
          UpdateBookCommand command = new UpdateBookCommand(_context);
          command.BookId = id;
          command.Model = updateBook;
          command.Handle();
        }
        catch (Exception ex)
        {
          return BadRequest(ex.Message);
        }
       
         return Ok();

         





       }
        

        [HttpDelete("{id}")]

         public IActionResult DeleteBook(int id)
         {
          try
          {
            DeleteBookCommand command = new DeleteBookCommand (_context);
            command.BookId = id;
            command.Handle();
          }
          catch (Exception ex)
          {
            
            return BadRequest(ex.Message);
          }
            
             return Ok();
         }



  
     }


}