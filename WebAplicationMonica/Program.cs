using WebAplicationMonica.Services;

namespace WebAplicationMonica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IRepositorioCurso,EFRepositorioCurso>();
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