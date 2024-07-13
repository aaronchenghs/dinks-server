using Microsoft.EntityFrameworkCore;

namespace dinks_server
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
