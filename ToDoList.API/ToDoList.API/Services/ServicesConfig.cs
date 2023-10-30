using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using ToDoList.API.Utils;

namespace ToDoList.API.Services
{
    public class ServicesConfig
    {
        private readonly IConnectionString _connection;
        private  string connectionString;

        public ServicesConfig(IConnectionString connection)
        {
            _connection = connection;
        }

        

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _connection.getConnection();
            services.AddDbContext<TodolistdcaContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
