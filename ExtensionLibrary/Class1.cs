using Microsoft.Extensions.DependencyInjection;
using WebAplicationMonica.CrossCuting.Logging;

namespace ExtensionLibrary
{
    public static class Extensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

    }
}