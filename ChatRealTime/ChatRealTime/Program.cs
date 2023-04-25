using ChatRealTime.Domain.Models;
using ChatRealTime.Hubs;
using ChatRealTime.Infrastructure.CrossCutting.Ioc;
using ChatRealTime.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

//builder.Services.Configure<AppSettings>(configuration);

builder.Services.RegisterServicesInjection();

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Database"));
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("connectionString")));

builder.Services.AddSignalR();

builder.Services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

builder.Services.AddIdentity<AppUserModel, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

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
app.UseAuthentication();

app.MapHub<ChatHub>("Home/Index");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
