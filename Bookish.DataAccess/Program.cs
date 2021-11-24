using System.Data;
using System.Data.SqlClient;

namespace Bookish.DataAccess
{
    public class Program
    {
        private IDbConnection db = new SqlConnection("Server=localhost;Database=Bookish;Trusted_Connection=True");

    }
}