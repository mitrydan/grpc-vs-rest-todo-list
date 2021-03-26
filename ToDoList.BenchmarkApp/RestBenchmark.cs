using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BenchmarkApp
{
    public class RestBenchmark : BenchmarkBase
    {
        private readonly HttpClient _httpClient;

        public RestBenchmark(int todosCount, HttpClient httpClient)
            : base(todosCount, nameof(RestBenchmark))
        {
            _httpClient = httpClient;
        }

        protected override async Task<bool> PingServiceAsync()
        {
            await _httpClient.GetAsync("/api/Todo");
            return true;
        }

        protected override async Task<bool> InsertTodosAsync(int todosCount)
        {
            for (int i = 0; i < todosCount; i++)
            {
                var content = new StringContent(JsonConvert.SerializeObject(new { ActionTitle = "ActionTitle", ActionDescription = "ActionDescription" }), Encoding.UTF8, "application/json");
                await _httpClient.PostAsync("/api/Todo", content);
            }
            return true;
        }

        protected override async Task<IEnumerable<TodoEntry>> GetTodosAsync()
        {
            var result = await _httpClient.GetAsync("/api/Todo");
            var resultString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<TodoEntry>>(resultString);
        }

        protected override async Task<bool> CompleteTodosAsync(IEnumerable<TodoEntry> todos)
        {
            foreach (var todo in todos)
            {
                var content = new StringContent(JsonConvert.SerializeObject(new { Id = todo.Id }), Encoding.UTF8, "application/json");
                await _httpClient.PutAsync($"/api/Todo/{todo.Id}/markcompleted", content);
            }
            return true;
        }
    }
}
