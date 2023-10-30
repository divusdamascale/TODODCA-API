
namespace ToDoList.API.Utils
{
    public class UtilsConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IConnectionString, ConnectionString>();
        }
    }
}
