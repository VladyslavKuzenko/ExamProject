using EasyLearn.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyLearn.MSSqlDb
{
    public class MSSqlDbContext : ApplicationDbContext
    {
        public MSSqlDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    
    }
}
