using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Shared.Commands;

namespace TodoApp.Domain.Commands.UserCommands.Inputs
{
    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand()
        {
            Notifications = new Dictionary<string, string>();
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public IDictionary<string, string> Notifications { get; set; }

        public bool Valid()
        {
            if (!Email.Contains("@"))
                Notifications.Add("Email", "Email must have an @.");

            if (Password.Length < 6)
                Notifications.Add("Password", "Password must have 6 or more characters.");

            return Notifications.Count == 0;
        }
    }
}
