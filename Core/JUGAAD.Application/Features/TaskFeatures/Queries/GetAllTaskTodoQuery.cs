using JUGAAD.Application.Interfaces;
using JUGAAD.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JUGAAD.Application.Features.TaskFeatures.Queries
{
    public class GetAllTaskTodoQuery : IRequest<IEnumerable<TaskTodo>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllTaskTodoQuery, IEnumerable<TaskTodo>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<TaskTodo>> Handle(GetAllTaskTodoQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.TasksTodo.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
