using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.TodoAppContext.Entities;
using TodoApp.Domain.TodoAppContext.Queries;

namespace TodoApp.Domain.TodoAppContext.Repositories
{
    public interface ITodoTaskRepository
    {
        Task<bool> TodoTaskExists(string description);
        Task<IEnumerable<ListTodoTasksQuery>> Get();
        Task Save(TodoTask todoTask);
    }
}
