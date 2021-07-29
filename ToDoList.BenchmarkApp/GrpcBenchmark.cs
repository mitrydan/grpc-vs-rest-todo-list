using Newtonsoft.Json;
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
			var request = new CreateTodoRequest
			{
				Request = JsonConvert.SerializeObject(new
				{
					ActionTitle = "ActionTitle",
					ActionDescription = "ActionDescription",
				})
			};

			await Task.WhenAll(
				Task.Run(async () =>
				{
					for (int i = 0; i < todosCount; i++)
					{
						await _client.CreateAsync(request);
					}
				}),
				Task.Run(async () =>
				{
					for (int i = 0; i < todosCount; i++)
					{
						await _client.CreateAsync(request);
					}
				}),
				Task.Run(async () =>
				{
					for (int i = 0; i < todosCount; i++)
					{
						await _client.CreateAsync(request);
					}
				})
			);

			return true;
		}

		protected override async Task GetTodosAsync()
		{
			var result = await _client.GetAsync(new GetTodosRequest());
		}
	}
}
