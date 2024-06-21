using Application.RentalCar;
using Infrastructure.RentalCar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration.GetSection("AppSettings");

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; //走哪一種驗證scheme類型
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(cookieOptions =>
{
    //cookieOptions.LoginPath = "/Account/Login";
    //cookieOptions.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    //不寫死，讓程式自己抓資料。
    cookieOptions.LoginPath = configuration.GetValue<string>("LoginPage");
    cookieOptions.ExpireTimeSpan = TimeSpan.FromMinutes(configuration.GetValue<int>("TimeoutMinutes"));
});

builder.Services.AddDbContext<SaleCarDbContext>(options =>
{
    //擴充方法需using
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IQueryRentalCarUseCase, RentalCarRepository>();
builder.Services.AddScoped<RentalCarService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
