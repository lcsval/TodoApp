using System;
using TodoApp.Domain.TodoAppContext.Services;

namespace TodoApp.Infra.TodoAppContext.Services
{
    public class EmailService : IEmailService
    {
        void IEmailService.Send(string to, string from, string subject, string body)
        {
            // Todo
        }
    }
}