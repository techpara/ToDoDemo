using ToDoDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoDemo.Data
{
    public class ToDoDemoDBContext : DbContext
    {
        public ToDoDemoDBContext(DbContextOptions<ToDoDemoDBContext> options)
            : base(options)
        {
        }

        public DbSet<ToDo> ToDo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().ToTable("ToDo");
        }
    }
}
