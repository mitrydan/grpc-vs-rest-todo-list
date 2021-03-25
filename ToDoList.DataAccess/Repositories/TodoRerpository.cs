using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.Commands;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;
using ToDoList.Domain.Queries;

namespace ToDoList.DataAccess.Repositories
{
    public class TodoRerpository : ITodoRerpository
    {
        private readonly TodoListContext _context;

        public TodoRerpository(TodoListContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<long> CreateTodoAsync(CreateTodoRequest request)
        {
            var entity = new Entities.TodoEntry
            {
                CreatedDateTime = DateTime.Now,
                ActionTitle = request.ActionTitle,
                ActionDescription = request.ActionDescription,
            };
            await _context.TodoEntries.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> MarkCompletedAsync(MarkCompletedRequest request)
        {
            var entity = await _context.TodoEntries.FindAsync(request.Id);

            if (entity == default)
                return false;

            entity.CompletedDateTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TodoEntry>> TodoEntryQueryAsync(GetTodosQuery query)
        {
            return await _context.TodoEntries
                .Select(x => new TodoEntry(x.Id, x.CreatedDateTime, x.CompletedDateTime, x.ActionTitle, x.ActionDescription))
                .ToListAsync();
        }
    }
}
