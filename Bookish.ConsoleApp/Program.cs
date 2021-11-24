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
            IDbConnection db = new SqlConnection("Server=localhost;Database=Bookish;Trusted_Connection=True");
            string SqlString = "SELECT TOP 100 [Id],[Title],[ISBN] FROM [Books]";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);
            
            foreach (var book in ourBooks)
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("\nBook ID: " + book.Id.ToString());
                Console.WriteLine("Title: " + book.Title);
                Console.WriteLine("ISBN " + book.Isbn + "\n");
                Console.WriteLine(new string('*', 20));
            }

        }
    }
}