using MediatR;

namespace ToDoList.Domain.Commands
{
    public sealed record CreateTodoRequest(string ActionTitle, string ActionDescription) : IRequest<long>;
}
