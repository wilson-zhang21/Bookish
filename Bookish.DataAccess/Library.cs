using System;

namespace Bookish.DataAccess
{
    public class Library
    {
        public int CopyId { get; set; }
        public int BookId { get; set; }
        public int? BorrowerId { get; set; }
        public DateTime DueDate { get; set; }
        
    }
}