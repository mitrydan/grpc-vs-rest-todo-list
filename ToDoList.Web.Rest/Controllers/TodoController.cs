using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Web.Rest.Contracts;

namespace ToDoList.Web.Rest.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		[HttpGet]
		public Task<IActionResult> Get()
		{
			return Task.FromResult<IActionResult>(Ok(Enumerable.Empty<TodoEntry>()));
		}

		[HttpPost]
		public Task<IActionResult> Create(CreateTodoRequest request)
		{
			return Task.FromResult<IActionResult>(Created(nameof(Create), 1));
		}
	}
}
