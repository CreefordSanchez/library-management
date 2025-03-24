using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.DAL;
using LibraryManagement.Models;
using LibraryManagement.BLL;

namespace LibraryManagement {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LibraryManagementContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<BookRepository>();
            builder.Services.AddTransient<BookReviewRepository>();
            builder.Services.AddTransient<EventRepository>();
            builder.Services.AddTransient<EventReviewRepository>();
            builder.Services.AddTransient<CheckOutRepository>();

            builder.Services.AddTransient<BookService>();
            builder.Services.AddTransient<BookReviewService>();
            builder.Services.AddTransient<EventService>();
            builder.Services.AddTransient<EventReviewService>();
            builder.Services.AddTransient<CheckOutService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}


