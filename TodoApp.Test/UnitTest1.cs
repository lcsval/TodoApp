using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Domain.TodoAppContext.Entities;

namespace TodoApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var user = new User("t","p");

            var task = new Task("Task1", 0);
            
        }
    }
}
