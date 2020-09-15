using JUGAAD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JUGAAD.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TaskTodo> TasksTodo { get; set; }
        Task<int> SaveChanges();
    }
}
