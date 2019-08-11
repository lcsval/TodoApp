using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Domain.TodoAppContext.Entities
{
    public class User
    {
        public User(string email, string password)
        {
            Email = email;
            Password = password;
            Notifications = new Dictionary<string, string>();

            Validate();
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public IDictionary<string, string> Notifications { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Email}";
        }

        private bool IsValidEmail(string source)
        {
            return new EmailAddressAttribute().IsValid(source);
        }

        public void Validate()
        {
            if (!IsValidEmail(Email))
                Notifications.Add("Email", "Email must be valid.");

            if (Password.Length < 6)
                Notifications.Add("Password", "Password must have 6 or more characters.");
        }
    }
}
