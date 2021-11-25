namespace Bookish.DataAccess
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string BorrowerId { get; set; }
    }
}