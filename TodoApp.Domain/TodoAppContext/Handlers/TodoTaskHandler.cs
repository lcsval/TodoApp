using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Commands.TodoTaskCommands.Inputs;
using TodoApp.Domain.Commands.TodoTaskCommands.Outputs;
using TodoApp.Domain.TodoAppContext.Entities;
using TodoApp.Domain.TodoAppContext.Repositories;
using TodoApp.Shared.Commands;

namespace TodoApp.Domain.TodoAppContext.Handlers
{
    public class TodoTaskHandler : ICommandHandler<CreateTodoTaskCommand>
    {

        private readonly ITodoTaskRepository _repository;

        public TodoTaskHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateTodoTaskCommand command)
        {
            if (await _repository.TodoTaskExists(command.Description))
                command.Notifications.Add("Description", "The task already exists.");

            var todoTask = new TodoTask(command.Description, command.IdUser);

            //Validate

            if (command.Notifications.Count > 0)
                return null;

            await _repository.Save(todoTask);

            return new CreateTodoTaskCommandResult(todoTask.Id, todoTask.Description, todoTask.IdUser, todoTask.CreateDate, (int)todoTask.Status);
        }
    }
}
