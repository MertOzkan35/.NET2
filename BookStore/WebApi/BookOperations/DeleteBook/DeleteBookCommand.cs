using System.Xml.XPath;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Data;
using System.Collections.Generic;
using WebApi.DBOperations;
using System.Linq;
using WebApi.Common;
using System;

 
namespace WebApi.BookOperations.DeleteBook
{


  public class DeleteBookCommand
  {

    private readonly BookStoreDbContext _dbContext;
    public int BookId {get; set;}
     public DeleteBookCommand(BookStoreDbContext dbContext)
     {
       _dbContext = dbContext;
     }
     public void Handle()
     {
        var book =  _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
        if (book is null)
          throw new InvalidOperationException("Kitap Bulunamadı");

          _dbContext.Books.Remove(book);
          _dbContext.SaveChanges();
     }
  }
  
  
 }