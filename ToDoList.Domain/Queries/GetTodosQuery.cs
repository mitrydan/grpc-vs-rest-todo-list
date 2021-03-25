using MediatR;
using System.Collections.Generic;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Queries
{
    public sealed record GetTodosQuery() : IRequest<IEnumerable<TodoEntry>>;
}
