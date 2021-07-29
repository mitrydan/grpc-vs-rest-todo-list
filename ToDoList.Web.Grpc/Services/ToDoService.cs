using Grpc.Core;
using System.Threading.Tasks;

namespace ToDoList.Web.Grpc
{
	public class ToDoService : ToDo.ToDoBase
	{
		public override Task<GetTodosResponse> Get(GetTodosRequest request, ServerCallContext context)
		{
			return Task.FromResult(new GetTodosResponse
			{
				Todos = "[]",
			});
		}

		public override Task<CreateTodoResponse> Create(CreateTodoRequest request, ServerCallContext context)
		{
			return Task.FromResult(new CreateTodoResponse
			{
				Id = 1,
			});
		}
	}
}
