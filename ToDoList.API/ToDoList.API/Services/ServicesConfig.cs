using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using ToDoList.API.Services.Interfaces;
using ToDoList.API.Utils;

namespace ToDoList.API.Services
{
    public class ServicesConfig
    {
        

        public static void ConfigureServices(IServiceCollection services,SettingsOptions option)
        {

            services.AddDbContext<TodolistdcaContext>(options =>
            {
                options.UseSqlServer(option.connectionstrings.toDoListConnection);
            });

            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IListService,ListService>();
        }
    }
}
