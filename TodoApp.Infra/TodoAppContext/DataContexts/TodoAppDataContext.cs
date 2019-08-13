using System;
using System.Data;
using Npgsql;
using TodoApp.Shared;

namespace TodoApp.Infra.TodoAppContext 
{
    public class TodoAppDataContext : IDisposable 
    {
        public NpgsqlConnection Connection {get; set;}

        public TodoAppDataContext()
        {
            Connection = new NpgsqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose() {
            try
            {
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }

        }
    }
}