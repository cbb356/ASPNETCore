/*
 * Завдання 1
 * У програмі SampleApp, з першого домашнього завдання, додайте у файл data.txt 
 * інформацію про те, в якій категорії знаходиться товар.
 * Модифікуйте контролер Products таким чином, щоб можна було через параметр 
 * у запиті отримати на сторінці продукти у зазначеній категорії. 
 * Наприклад:
 * localhost:50234/products/list – всі продукти;
 * localhost:50234/products/list/pc – всі продукти, у категорії pc;
 * localhost:50234/products/list/office – всі продукти у категорії office.
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
