using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<TodoListContext>(options => options.UseInMemoryDatabase("TodoList"));
        }
    }
}
