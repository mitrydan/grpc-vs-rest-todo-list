using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoList.DataAccess.Entities;

namespace ToDoList.DataAccess
{
    public class TodoListContext : DbContext
    {
        public DbSet<TodoEntry> TodoEntries { get; set; }

        public TodoListContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
