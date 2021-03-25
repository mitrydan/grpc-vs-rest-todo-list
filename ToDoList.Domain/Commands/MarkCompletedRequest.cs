using MediatR;

namespace ToDoList.Domain.Commands
{
    public record MarkCompletedRequest(long Id) : IRequest<bool>;
}
