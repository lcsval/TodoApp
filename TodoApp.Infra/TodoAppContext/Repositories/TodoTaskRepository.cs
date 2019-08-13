using Dapper;
using TodoApp.Domain.TodoAppContext.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoApp.Domain.TodoAppContext.Queries;
using TodoApp.Domain.TodoAppContext.Repositories;
using System;

namespace TodoApp.Infra.TodoAppContext.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly TodoAppDataContext _context;

        public TodoTaskRepository(TodoAppDataContext context)
        {
            _context = context;
        }

        public async Task<bool> TodoTaskExists(string description)
        {
            var sql = $"select exists (select * from public.todotask where description = '${description}')";
            return await _context.Connection.QueryFirstAsync<bool>(sql);
        }

        public async Task Save(TodoTask todoTask)
        {
            if (todoTask.Id > 0)
            {
                var sql = @"
                    INSERT INTO
                        todotask (description, createdate, status, enddate, iduser)
                    VALUES
                        (@Description, @CreateDate, @Status, @EndDate, @IdUser";

                await _context.Connection.ExecuteAsync(sql, todoTask);
            }
            else
            {
                var sql = @"
                    UPDATE 
                        todotask 
                    SET 
                        description = @Description,
                        createdate = @CreateDate,
                        status = @Status,
                        enddate = @EndDate,
                        iduser = @IdUser
                    WHERE 
                        id = @Id;";

                await _context.Connection.ExecuteAsync(sql, todoTask);
            }
        }

        public async Task<IEnumerable<ListTodoTasksQuery>> Get()
        {
            try
            {
                var sql = $"select * from public.todotask";
                return await _context.Connection.QueryAsync<ListTodoTasksQuery>(sql);

            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }

            return null;
        }
    }
}
