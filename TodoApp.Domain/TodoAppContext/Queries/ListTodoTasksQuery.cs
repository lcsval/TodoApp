namespace TodoApp.Domain.TodoAppContext.Queries
{
    public class ListTodoTasksQuery
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public int IdUser { get; set; }
    }
}
