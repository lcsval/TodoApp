using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoApp.Domain.TodoAppContext.Entities;
using TodoApp.Domain.TodoAppContext.Enums;

namespace TodoApp.Test.Entities
{
    [TestClass]
    public class TaskTests
    {
        private TodoTask _validTask;
        private TodoTask _invalidTask;

        public TaskTests()
        {
            _validTask = new TodoTask("New task 1", 1);
            _invalidTask = new TodoTask("", 0);
        }

        [TestMethod]
        public void ShouldReturnInProgressWhenTaskIsCreated()
        {
            Assert.AreEqual(EStatus.InProgress, _validTask.Status);
        }

        [TestMethod]
        public void ShouldReturnDoneWhenTaskIsCompleted()
        {
            _validTask.CompleteTask();
            Assert.AreEqual(EStatus.Done, _validTask.Status);
        }

        [TestMethod]
        public void ShouldReturnRemoveWhenTaskIsRemoved()
        {
            _validTask.RemoveTask();
            Assert.AreEqual(EStatus.Removed, _validTask.Status);
        }

        [TestMethod]
        public void ShouldReturnValidCreatedDateWhenTaskIsCreated()
        {
            Assert.AreNotEqual(null, _validTask.CreateDate);
        }

        [TestMethod]
        public void ShouldReturnValidEndDateWhenTaskIsCompleted()
        {
            _validTask.CompleteTask();
            Assert.AreNotEqual(null, _validTask.EndDate);
        }

        [TestMethod]
        public void ShouldReturnValidTaskWhenAValidTaskIsCreated()
        {
            Assert.AreEqual(0, _validTask.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnInvalidTaskWhenAInvalidTaskIsCreated()
        {
            Assert.IsTrue(_invalidTask.Notifications.Count > 0);
        }
    }
}