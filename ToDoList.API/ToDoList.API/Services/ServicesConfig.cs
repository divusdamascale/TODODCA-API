using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using ToDoList.API.Services.Interfaces;
using ToDoList.API.Utils;

namespace ToDoList.API.Services
{
    public class ServicesConfig
    {

        public static void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TodolistdcaContext>(options =>
            {
                options.UseSqlServer(ConnectionString.getConnection());
            });

            services.AddScoped<IAuthService,AuthService>();
        }
    }
}
