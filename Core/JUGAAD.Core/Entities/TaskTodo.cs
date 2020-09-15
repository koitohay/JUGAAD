using JUGAAD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JUGAAD.Domain.Entities
{
    public class TaskTodo : BaseEntity
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
    }
}
