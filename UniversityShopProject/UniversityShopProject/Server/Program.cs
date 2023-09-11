using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using UniversityShopProject.Server.Classes;
using UniversityShopProject.Server.Classes.MappingProfile;
using UniversityShopProjectModels.Context;

namespace UniversityShopProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture
  = CultureInfo.DefaultThreadCurrentUICulture
  = PersianDateExtensionMethods.GetPersianCulture();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(UserMapProfile));
            builder.Services.AddAutoMapper(typeof(AdminMapProfile));
            builder.Services.AddAutoMapper(typeof(CategoryMapProfile));
            builder.Services.AddAutoMapper(typeof(CommentMapProfile));
            builder.Services.AddHttpClient();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}