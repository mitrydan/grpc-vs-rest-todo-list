using Newtonsoft.Json;
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
			var content = new StringContent(
				JsonConvert.SerializeObject(new
				{
					ActionTitle = "ActionTitle",
					ActionDescription = "ActionDescription"
				}),
				Encoding.UTF8,
				"application/json");

			await Task.WhenAll(
				Task.Run(async () =>
				{
					for (int i = 0; i < todosCount; i++)
					{
						await _httpClient.PostAsync("/api/Todo", content);
					}
				}),
				Task.Run(async () =>
				{
					for (int i = 0; i < todosCount; i++)
					{
						await _httpClient.PostAsync("/api/Todo", content);
					}
				}),
				Task.Run(async () =>
				{
					for (int i = 0; i < todosCount; i++)
					{
						await _httpClient.PostAsync("/api/Todo", content);
					}
				})
			);

			return true;
		}

		protected override async Task GetTodosAsync()
		{
			var result = await _httpClient.GetAsync("/api/Todo");
		}
	}
}
