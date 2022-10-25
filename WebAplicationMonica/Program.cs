using NLog;
using WebAplicationMonica.CrossCuting.Exceptions;
using WebAplicationMonica.CrossCuting.Logging;
using WebAplicationMonica.Services;

namespace WebAplicationMonica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //https://code-maze.com/net-core-web-development-part3/
            //https://www.andlearning.org/catch-exception-using-a-middleware-in-asp-net-core/
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
            builder.Services.AddScoped<IRepositorioCurso,EFRepositorioCurso>();
            builder.Services.AddScoped<IRepositorioModulo,EFRepositorioModulo>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            // Middleware

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionMiddleware();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cursos}/{action=Index}/{id?}");

            app.Run();
        }
    }
}