using Grpc.Core;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using ToDoList.Domain.Queries;

namespace ToDoList.Web.Grpc
{
    public class ToDoService : ToDo.ToDoBase
    {
        private readonly IMediator _mediator;

        public ToDoService(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override async Task<GetTodosResponse> Get(GetTodosRequest request, ServerCallContext context)
        {
            var list = await _mediator.Send(new GetTodosQuery());
            return new GetTodosResponse
            {
                Todos = JsonConvert.SerializeObject(list),
            };
        }

        public override async Task<CreateTodoResponse> Create(CreateTodoRequest request, ServerCallContext context)
        {
            var id = await _mediator.Send(new Domain.Commands.CreateTodoRequest(request.ActionTitle, request.ActionDescription));
            return new CreateTodoResponse
            {
                Id = id,
            };
        }

        public override async Task<MarkCompletedResponse> MarkCompleted(MarkCompletedRequest request, ServerCallContext context)
        {
            var success = await _mediator.Send(new Domain.Commands.MarkCompletedRequest(request.Id));
            return new MarkCompletedResponse
            {
                Success = success,
            };
        }
    }
}
