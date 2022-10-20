using NLog;
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
        //https://www.c-sharpcorner.com/UploadFile/deveshomar/extension-method-in-C-Sharp/#:~:text=Create%20And%20Use%20An%20Extension%20Method%20In%20C%23,6.%20Add%20an%20Extension%20class.%20...%20M%C3%A1s%20elementos
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
                app.UseExceptionHandler("/Home/Error");
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