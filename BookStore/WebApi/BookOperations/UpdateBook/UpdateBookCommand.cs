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

 
namespace WebApi.BookOperations.UpdateBook
{


  public class UpdateBookCommand
  {
    private readonly BookStoreDbContext _context;
    public int BookId {get; set;}
    public UpdateBookModel Model {get; set;}
    public UpdateBookCommand(BookStoreDbContext context)
    {
        _context = context;

    }

    public void Handle()
    {
        var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

        if (book is null)
        throw new InvalidOperationException("Kitap Bulunamadı");

        book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        book.Title = Model.Title != default ? Model.Title : book.Title;
        _context.SaveChanges();
    }

    public class UpdateBookModel
    {
        public string Title {get; set;}

        public int GenreId {get; set;}
    }

  }
  
  }