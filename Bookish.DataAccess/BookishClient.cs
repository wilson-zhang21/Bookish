using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Bookish.DataAccess
{
    public class BookishClient
    {
        private string ConnectionString { get; set; }

        public BookishClient(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IEnumerable<Book> GetAllCopies()
        {
            var db = new SqlConnection(ConnectionString);
            return db.Query<Book>("SELECT Id, Title, ISBN FROM Library INNER JOIN Books on Library.BookId = Books.Id");
        }

        public IEnumerable<Book> GetAvailableCopies()
        {
            var db = new SqlConnection(ConnectionString);
            return db.Query<Book>("SELECT Id, Title, ISBN FROM Library INNER JOIN Books on Library.BookId = Books.Id WHERE Library.BorrowerId IS NULL");
        }


        public void AddBook(Book book, int numCopies)
        {
           var db = new SqlConnection(ConnectionString);
           int bookId = db.QuerySingle<int>(
               "INSERT INTO Books(Title, ISBN) VALUES(@Title, @ISBN); SELECT Id FROM Books WHERE Id = @@Identity", book);
           book.Id = bookId;
           
           for (var i = 0; i < numCopies; i++)
           {
               db.Execute("INSERT INTO Library(BookId) VALUES(@Id)", book);
           }

        }

        public void LoanBook(Book book)
        {
            var db = new SqlConnection(ConnectionString);
            int bookId = db.QueryFirstOrDefault<int>(
                "SELECT Id FROM Books WHERE Title = @Title", book);
            
            if (bookId != 0)
            {
                book.Id = bookId;
                db.Execute("UPDATE Library SET BorrowerId= 111 WHERE BookId = @Id", book);
            }


        }

        public IEnumerable<Book> GetBooksOnLoan()
        {
            var db = new SqlConnection(ConnectionString);
            return db.Query<Book>("SELECT Id, Title, ISBN, BorrowerId FROM Library INNER JOIN Books on Library.BookId = Books.Id WHERE Library.BorrowerId IS NOT NULL");
        }
        

    }
}