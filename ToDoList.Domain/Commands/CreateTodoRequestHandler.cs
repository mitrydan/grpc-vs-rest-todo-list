using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Domain.Commands
{
    public class CreateTodoRequestHandler : IRequestHandler<CreateTodoRequest, long>
    {
        private readonly ITodoRerpository _rerpository;

        public CreateTodoRequestHandler(ITodoRerpository rerpository)
        {
            _rerpository = rerpository ?? throw new ArgumentNullException(nameof(rerpository));
        }

        public Task<long> Handle(CreateTodoRequest request, CancellationToken cancellationToken)
        {
            return _rerpository.CreateTodoAsync(request);
        }
    }
}
