using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using ELibrary.Persistence.Context;
using ELibrary.Persistence.Repositories;
using ELibrary.WebUI.Models;
using ELibrary.WebUI.Services.EmailServices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ELibraryContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDbContext<ELibraryContext>();
builder.Services.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<ELibraryContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IBookRepository, BookRepository>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
