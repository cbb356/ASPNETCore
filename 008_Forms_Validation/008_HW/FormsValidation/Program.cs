/*
Завдання 1
Створіть форму реєстрації на консультацію. У формі мають бути поля:
Ім'я
Прізвище
Email
Бажана дата консультації
Усі поля є обов'язковими для введення. Email має бути у відповідному форматі. 
Дата консультації має бути правильною датою, вона має бути у майбутньому 
і не повинна потрапляти на вихідні дні.
За наявності помилок, необхідно повідомити користувача про помилки.

Завдання 2
Для форми із попереднього завдання додайте валідацію на стороні клієнта.

Завдання 3
Для форми з попереднього завдання додайте список, в якому можна буде вказати продукт, 
за яким клієнт хоче отримати консультацію. Значення: JavaScript, C#, Java, Python, Основи. 
При цьому консультація щодо продукту «Основи» не може проходити по понеділках, 
відповідна помилка повинна виводитися в інтерфейсі користувача.
 */

namespace FormsValidation
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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
