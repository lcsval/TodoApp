﻿using TodoApp.Shared.Commands;

namespace TodoApp.Domain.Commands.TodoTaskCommands.Outputs
{
    public class CreateTodoTaskCommandResult : ICommandResult
    {
        public CreateTodoTaskCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
