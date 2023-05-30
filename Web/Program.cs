using BusinessLogic.Services;
using DataAccess.Wrapper;
using DataAccess;
using Domain.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Web.Data;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<shop_pharmacyContext>(
                options => options.UseSqlServer("Server=lab116-p; Database=shop_pharmacy; User Id = sa; Password = 12345;"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<IFilterService, FilterService>();
            builder.Services.AddScoped<IOrderingService, OrderingService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ISavedAddressService, SavedAddressService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}