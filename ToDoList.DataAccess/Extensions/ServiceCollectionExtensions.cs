using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.DataAccess.Repositories;
using ToDoList.Domain.Interfaces;

namespace ToDoList.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<TodoListContext>(options => options.UseInMemoryDatabase("TodoList"));

            serviceCollection.AddTransient<ITodoRerpository, TodoRerpository>();
        }
    }
}
