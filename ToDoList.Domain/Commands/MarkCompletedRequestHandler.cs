using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Domain.Commands
{
    public class MarkCompletedRequestHandler : IRequestHandler<MarkCompletedRequest, bool>
    {
        private readonly ITodoRerpository _rerpository;

        public MarkCompletedRequestHandler(ITodoRerpository rerpository)
        {
            _rerpository = rerpository ?? throw new ArgumentNullException(nameof(rerpository));
        }

        public Task<bool> Handle(MarkCompletedRequest request, CancellationToken cancellationToken)
        {
            return _rerpository.MarkCompletedAsync(request);
        }
    }
}
