using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.BenchmarkApp
{
    public class GrpcBenchmark : BenchmarkBase
    {
        private readonly ToDo.ToDoClient _client;

        public GrpcBenchmark(int todosCount, ToDo.ToDoClient client)
            : base(todosCount, nameof(GrpcBenchmark))
        {
            _client = client;
        }

        protected override async Task<bool> PingServiceAsync()
        {
            await _client.GetAsync(new GetTodosRequest());
            return true;
        }

        protected override async Task<bool> InsertTodosAsync(int todosCount)
        {
            for (int i = 0; i < todosCount; i++)
            {
                await _client.CreateAsync(new CreateTodoRequest
                {
                    ActionTitle = "ActionTitle",
                    ActionDescription = "ActionDescription",
                });
            }
            return true;
        }

        protected override async Task<IEnumerable<TodoEntry>> GetTodosAsync()
        {
            var result = await _client.GetAsync(new GetTodosRequest());
            return JsonConvert.DeserializeObject<IEnumerable<TodoEntry>>(result.Todos);
        }

        protected override async Task<bool> CompleteTodosAsync(IEnumerable<TodoEntry> todos)
        {
            foreach (var todo in todos)
            {
                await _client.MarkCompletedAsync(new MarkCompletedRequest
                {
                    Id = todo.Id,
                });
            }
            return true;
        }
    }
}
