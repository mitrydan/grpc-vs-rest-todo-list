using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ToDoList.BenchmarkApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Benchmark started");

			using var httpClient = new HttpClient
			{
				BaseAddress = new Uri("http://localhost:8081")
			};

			using var channel = GrpcChannel.ForAddress("http://localhost:8082");
			var grpcClient = new ToDo.ToDoClient(channel);

			var benchmarks = new List<BenchmarkBase> {
				new GrpcBenchmark(1000, grpcClient),
				new RestBenchmark(1000, httpClient),
			};

			foreach (var benchmark in benchmarks)
			{
				Console.WriteLine($"Run {benchmark.Title} ...");

				var duration = await benchmark.RunTestAsync();

				Console.WriteLine($"{benchmark.Title} competed with {duration} ms");
			}

			Console.WriteLine("Benchmark completed");
		}
	}
}
