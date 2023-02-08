using Business.Services.Abstract;
using Business.Services.Conrete;
using Core.Entities;
using Core.Utilities.FileService;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using AdminConcreteService = Business.Areas.Admin.Services.Concrete;
using AdminAsbtractService = Business.Areas.Admin.Services.Asbract;
var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
//builder.Services.AddSingleton<IFileService, FileService>();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString, x => x.MigrationsAssembly("DataAccess")));
builder.Services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();



builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 8;
    opt.Password.RequireUppercase = false;
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.AllowedForNewUsers = true;
});

#region Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketProductRepository, BasketProductRepository>();
builder.Services.AddScoped<IProductPhotoRepository, ProductPhotoRepository>();
builder.Services.AddScoped<IProductColorRepository, ProductColorRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IHomeMainSliderRepository, HomeMainSliderRepository>();
builder.Services.AddScoped<IOurServiceRepository, OurServiceRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();





#endregion

#region Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IFavouriteService, FavouriteService>();
builder.Services.AddScoped<IShopService, ShopService>();









builder.Services.AddScoped<AdminAsbtractService.IProductService, AdminConcreteService.ProductService>();
builder.Services.AddScoped<AdminAsbtractService.IBrandService, AdminConcreteService.BrandService>();
builder.Services.AddScoped<AdminAsbtractService.IBrandService, AdminConcreteService.BrandService>();
builder.Services.AddScoped<AdminAsbtractService.ISizeService, AdminConcreteService.SizeService>();
builder.Services.AddScoped<AdminAsbtractService.IColorService, AdminConcreteService.ColorService>();
builder.Services.AddScoped<AdminAsbtractService.IHomeMainSliderService, AdminConcreteService.HomeMainSliderService>();
builder.Services.AddScoped<AdminAsbtractService.IOurServiceService, AdminConcreteService.OurServiceService>();
builder.Services.AddScoped<AdminAsbtractService.ITestimonialService, AdminConcreteService.TestimonialService>();





#endregion



var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using (var scope = scopeFactory.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

    await DbInitialize.SeedAsync(userManager, roleManager);

}

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

app.UseAuthorization();

app.MapControllerRoute(
        name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=Index}/{id?}");

app.Run();