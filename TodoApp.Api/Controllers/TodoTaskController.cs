using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Commands.TodoTaskCommands.Inputs;
using TodoApp.Domain.TodoAppContext.Entities;
using TodoApp.Domain.TodoAppContext.Handlers;
using TodoApp.Domain.TodoAppContext.Queries;
using TodoApp.Domain.TodoAppContext.Repositories;
using TodoApp.Shared.Commands;

namespace TodoApp.Api.Controllers
{
    public class TodoTaskController : Controller
    {
        private readonly ITodoTaskRepository _repository;
        private readonly TodoTaskHandler _handler;

        public TodoTaskController(ITodoTaskRepository repository,
            TodoTaskHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<IEnumerable<ListTodoTasksQuery>> Get()
        {
            var result = await _repository.Get();
            return result;
        }

        [HttpGet]
        [Route("tasks/{id}")]
        //[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public TodoTask GetById(int id)
        {
            var task = new TodoTask("New task", 1);
            return task;
        }

        [HttpPost]
        [Route("tasks")]
        public Task<ICommandResult> Post([FromBody]CreateTodoTaskCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("tasks/{id}")]
        public TodoTask Put([FromBody]CreateTodoTaskCommand command) //Criar command
        {
            var task = new TodoTask(command.Description, command.IdUser);
            return task;
        }

        [HttpDelete]
        [Route("tasks/{id}")]
        public object Delete(int id)
        {
            return new { message = "Cliente removido com sucesso!" };
        }
    }
}