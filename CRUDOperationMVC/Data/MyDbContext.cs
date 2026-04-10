using Microsoft.EntityFrameworkCore;
using CRUDOperationMVC.Entities;

namespace CRUDOperationMVC.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}
