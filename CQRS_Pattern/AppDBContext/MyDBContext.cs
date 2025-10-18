using CQRS_Pattern.Entity;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Pattern.AppDBContext
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
