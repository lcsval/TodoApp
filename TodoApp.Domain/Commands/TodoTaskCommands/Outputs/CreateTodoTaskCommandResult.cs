using System;
using TodoApp.Shared.Commands;

namespace TodoApp.Domain.Commands.TodoTaskCommands.Outputs
{
    public class CreateTodoTaskCommandResult : ICommandResult
    {
        public CreateTodoTaskCommandResult() { }

        public CreateTodoTaskCommandResult(int id, string description, int idUser, DateTime createDate, int status)
        {
            Id = id;
            Description = description;
            IdUser = IdUser;
            CreateDate = createDate;
            Status = status;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
    }
}
