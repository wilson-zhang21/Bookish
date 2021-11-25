using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Bookish.DataAccess;
using Dapper;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bookish = new BookishClient();
           // bookish.GetAllBooks();
            
            /*
            IDbConnection db = new SqlConnection("Server=localhost;Database=Bookish;Trusted_Connection=True");
            string SqlString = "SELECT TOP 100 [Id],[Title],[ISBN] FROM [Books]";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);
            
            */
            
            var bookish = new BookishClient("Server=localhost;Database=Bookish;Trusted_Connection=True");
            var myBook = new Book();
            myBook.Isbn = "12345";
            myBook.Title = "Test 2Book";
            
          //  bookish.AddBook(myBook, 1);
            bookish.LoanBook(myBook);

            var ourBooks = bookish.GetBooksOnLoan();
           
            foreach (var book in ourBooks)
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("\nBook ID: " + book.Id.ToString());
                Console.WriteLine("Title: " + book.Title);
                Console.WriteLine("ISBN " + book.Isbn);
                Console.WriteLine("Borrowed by " + book.BorrowerId + "\n");
                Console.WriteLine(new string('*', 20));
            }

        }

        }
    
}