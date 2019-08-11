using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Domain.TodoAppContext.Entities;

namespace TodoApp.Test.Entities
{
    [TestClass]
    public class UserTests
    {
        private User _validUser;
        private User _invalidUser;

        public UserTests()
        {
            _validUser = new User("email@hello.com", "password123");
            _invalidUser = new User("", "");
        }

        [TestMethod]
        public void ShouldReturnAValidUser()
        {
            Assert.AreEqual(0, _validUser.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnAInvalidUser()
        {
            Assert.IsTrue(_invalidUser.Notifications.Count > 0);
        }
    }
}
