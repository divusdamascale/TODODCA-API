using ToDoList.API.Repositories.Interfaces;

namespace ToDoList.API.Repositories
{
    public class RepoConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>(); 
            services.AddScoped<IListRepository, ListRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }
    }
}
