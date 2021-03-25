using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Queries
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<TodoEntry>>
    {
        private readonly ITodoRerpository _rerpository;

        public GetTodosQueryHandler(ITodoRerpository rerpository)
        {
            _rerpository = rerpository ?? throw new ArgumentNullException(nameof(rerpository));
        }

        public Task<IEnumerable<TodoEntry>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return _rerpository.TodoEntryQueryAsync(request);
        }
    }
}
