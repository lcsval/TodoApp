using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.TodoAppContext.Entities;

namespace TodoApp.Domain.TodoAppContext.Repositories
{
    public interface ITodoTaskRepository
    {
        Task<bool> TodoTaskExists(string description);
        Task Save(TodoTask todoTask);
    }
}
