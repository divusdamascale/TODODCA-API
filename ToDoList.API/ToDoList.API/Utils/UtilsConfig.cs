
using ToDoList.API.Utils.Interfaces;

namespace ToDoList.API.Utils
{
    public class UtilsConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IJWTUtils, JWTUtils>();
        }
    }
}
