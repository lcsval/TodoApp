using System;
using TodoApp.Domain.TodoAppContext.Repositories;
using Dapper;
using TodoApp.Infra.TodoAppContext;
using TodoApp.Domain.TodoAppContext.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace TodoApp.Infra.Repositories
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
            if (todoTask.Id > 0) {
                var sql = @"
                    INSERT INTO
                        todotask (description, createdate, status, enddate, iduser)
                    VALUES
                        (@Description, @CreateDate, @Status, @EndDate, @IdUser";

                await _context.Connection.ExecuteAsync(sql, todoTask);
            }
            else {
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
    }
}
