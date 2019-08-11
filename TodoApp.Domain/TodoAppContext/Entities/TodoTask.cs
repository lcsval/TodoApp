using System;
using System.Collections.Generic;
using TodoApp.Domain.TodoAppContext.Enums;

namespace TodoApp.Domain.TodoAppContext.Entities
{
    public class TodoTask
    {
        public TodoTask(string description, int idUser)
        {
            Description = description;
            IdUser = idUser;
            CreateDate = DateTime.Now;
            Status = EStatus.InProgress;
            Notifications = new Dictionary<string, string>();

            Validate();
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EStatus Status { get; private set; }
        public DateTime? EndDate { get; private set; }
        public int IdUser { get; private set; }

        public IDictionary<string, string> Notifications { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Description}";
        }

        public void CompleteTask()
        {
            Status = EStatus.Done;
            EndDate = DateTime.Now;
        }

        public void RemoveTask()
        {
            Status = EStatus.Removed;
        }

        public void Validate()
        {
            if (Status == EStatus.Done)
                Notifications.Add("Status", "Task is already completed.");

            if (Status == EStatus.Removed)
                Notifications.Add("Status", "Task is already removed.");

            if (Description.Length < 3)
                Notifications.Add("Description", "Task needs to have 3 or more characters.");

            if (IdUser < 1)
                Notifications.Add("IdUser", "Task needs to have an user.");
        }
    }
}
