using EasyLearn.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyLearn.SqlLiteDb
{
    public class SqlLiteDbContext : ApplicationDbContext
    {
        public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options) 
        : base(options)
        {
        }
    }
}
