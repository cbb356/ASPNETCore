/*
 * Завдання 1
 * Доопрацюйте програму SimpleApp. До файлу data.txt додайте додаткову інформацію про продукт – опис 
 * продукту, кількість одиниць на складі. Додайте в опис Details опис продукту і кількість одиниць 
 * на складі. У поданні List зробіть так, щоб якщо продукту на складі немає, відображалося 
 * повідомлення навпроти продукту - немає в наявності, якщо кількість до 5 одиниць на складі - 
 * закінчується, якщо більше 5 одиниць - в наявності.
 * 
 * Завдання 2
 * Зробіть так, щоб у програмі SimpleApp за адресою Home/Index поверталося відображення. 
 * Зробіть у цьому відображенні посилання «Завантажити опис уроку». При натисканні на посилання 
 * повинен завантажуватися цей файл.
 */

namespace SimpleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // AddMvc - додає послуги, необхідні для роботи MVC, включаючи Razor-сторінки
            // services.AddMvc();

            // AddControllersWithViews - додає послуги, необхідні для роботи MVC,
            // Не включаючи Razor-сторінки - тільки контролери та уявлення.
            // Для прикладів цього курсу цього достатньо.
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
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Products}/{action=List}/{id?}");

            // {id?} - цей фрагмент шаблону описує не обов'язковий сегмент на адресу запиту.
            // При цьому в контролерах на ім'я id можна буде отримати інформацію, яка надійшла в запиті
            // Products/Details/10
            // {controller} = Products
            // {action} = Details
            // {id} = 10

            app.Run();
        }
    }
}
