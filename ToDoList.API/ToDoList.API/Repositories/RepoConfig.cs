﻿using ToDoList.API.Repositories.Interfaces;

namespace ToDoList.API.Repositories
{
    public class RepoConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>(); 
        }
    }
}
