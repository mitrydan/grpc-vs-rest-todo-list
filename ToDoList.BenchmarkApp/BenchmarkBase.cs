using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ToDoList.BenchmarkApp
{
	public abstract class BenchmarkBase
	{
		private readonly int _todosCount;

		public string Title { get; private set; }

		protected BenchmarkBase(int todosCount, string title)
		{
			_todosCount = todosCount;
			Title = title;
		}

		protected abstract Task<bool> PingServiceAsync();

		protected abstract Task<bool> InsertTodosAsync(int todosCount);

		protected abstract Task GetTodosAsync();

		public async Task<long> RunTestAsync()
		{
			var success = await PingServiceAsync();

			if (!success)
				return 0;

			var watch = Stopwatch.StartNew();

			await InsertTodosAsync(_todosCount);
			await GetTodosAsync();

			watch.Stop();

			return watch.ElapsedMilliseconds;
		}
	}
}
