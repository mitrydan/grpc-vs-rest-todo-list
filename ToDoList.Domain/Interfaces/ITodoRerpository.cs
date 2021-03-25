using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain.Commands;
using ToDoList.Domain.Models;
using ToDoList.Domain.Queries;

namespace ToDoList.Domain.Interfaces
{
    public interface ITodoRerpository
    {
        public Task<long> CreateTodoAsync(CreateTodoRequest request);

        public Task<bool> MarkCompletedAsync(MarkCompletedRequest request);

        public Task<IEnumerable<TodoEntry>> TodoEntryQueryAsync(GetTodosQuery query);
    }
}
