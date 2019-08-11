using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Commands.TodoTaskCommands.Inputs;
using TodoApp.Domain.TodoAppContext.Handlers;
using TodoApp.Test.Fakes;

namespace TodoApp.Test.Handlers
{
    [TestClass]
    public class TodoTasksHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterTodoTaskWhenCommandIsValid()
        {
            var command = new CreateTodoTaskCommand();
            command.Description = "new task";
            command.IdUser = 1;

            Assert.AreEqual(true, command.Valid());

            // var handler = new TodoTaskHandler(new FakeTodoTaskRepository());
            // var result = handler.Handle(command);

            // Assert.AreNotEqual(null, result);
            //Assert.AreEqual(true, handler.)
        }
    }
}
