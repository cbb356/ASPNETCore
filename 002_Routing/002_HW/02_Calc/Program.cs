/*
 * Створіть веб-додаток, який оброблятиме наступні запити:
 * Calc/Add/20/10 виконує додавання та повертає значення 30;
 * Calc/Mul/20/10 виконує множення та повертає значення 200;
 * Calc/Div/20/10 виконує ділення та повертає значення 2;
 * Calc/Sub/20/10 виконує віднімання та повертає значення 10.
 */

namespace Calc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "Calculations",
                pattern: "{controller=Calc}/{action}/{x}/{y}")
                .WithStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
