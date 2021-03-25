using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoList.Domain.Commands;
using ToDoList.Domain.Queries;

namespace ToDoList.Web.Rest.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _mediator.Send(new GetTodosQuery());
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoRequest request)
        {
            var id = await _mediator.Send(request);
            return Created(nameof(Create), id);
        }

        [HttpPut("{id:long}/markcompleted")]
        public async Task<IActionResult> MarkCompleted(long id, MarkCompletedRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var success = await _mediator.Send(request);
            return Ok(success);
        }
    }
}
