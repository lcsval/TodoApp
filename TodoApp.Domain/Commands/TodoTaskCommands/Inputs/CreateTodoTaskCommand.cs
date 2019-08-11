using System;
using System.Collections.Generic;
using TodoApp.Shared.Commands;

namespace TodoApp.Domain.Commands.TodoTaskCommands.Inputs
{
    public class CreateTodoTaskCommand : ICommand
    {
        public CreateTodoTaskCommand()
        {
            Notifications = new Dictionary<string, string>();
        }

        public string Description { get; set; }
        public int IdUser { get; set; }
        public IDictionary<string, string> Notifications { get; set; }

        public bool Valid()
        {
            if (Description.Length < 3)
                Notifications.Add("Description", "The task must have at leat 3 characters");

            if (IdUser < 1)
                Notifications.Add("IdUser", "The user id is required");

            return Notifications.Count == 0;
        }
    }
}
