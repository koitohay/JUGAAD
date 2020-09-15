using JUGAAD.Application.Interfaces;
using JUGAAD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JUGAAD.Application.Features.TaskFeatures.Commands
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateTaskCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
            {
                var task = new TaskTodo();
                task.Name = command.Name;
                task.Completed = command.Completed;
                task.Description = command.Description;
                _context.TasksTodo.Add(task);
                await _context.SaveChanges();
                return task.Id;
            }
        }
    }
}
