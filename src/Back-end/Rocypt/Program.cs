using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Rocypt.Data;
using Rocypt.Helpers;
using Rocypt.Repositorio;

namespace Rocypt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DatabankContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));
                });

            // Add services to the container.
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IGrupoRepositorio, GrupoRepositorio>();
            builder.Services.AddScoped<IPasswordDataRepositorio, PasswordDataRepositorio>();
            builder.Services.AddScoped<IEmail, Email>();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddControllersWithViews();

            builder.Services.Configure<CookiePolicyOptions>(Options =>
            {
                Options.CheckConsentNeeded = context => true;
                Options.MinimumSameSitePolicy = SameSiteMode.None;

            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
            {
                options.AccessDeniedPath = "/";
                options.LoginPath = "/Login";
            });

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(80);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}