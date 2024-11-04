using ELibrary.Application.Features.CQRS.Handlers.ApplicationUserCommandHandlers;
using ELibrary.Application.Features.Mediator.Commands.AuthorCommands;
using ELibrary.Application.Features.Mediator.Commands.BookCommands;
using ELibrary.Application.Features.Mediator.Commands.CategoryCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Application.Mapping;
using ELibrary.Domain.Entities;
using ELibrary.Persistence.Context;
using ELibrary.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ELibraryContext>(options =>
    options.UseNpgsql(connectionString));

//builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
//    .AddEntityFrameworkStores<ELibraryContext>().AddDefaultTokenProviders();

builder.Services.AddIdentity<ApplicationUser,ApplicationRole>().AddEntityFrameworkStores<ELibraryContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ApplicationUserRegisterCommandHandler>();

builder.Services.AddAutoMapper(typeof(GeneralMapping));

//Author
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CreateAuthorCommand).Assembly);

builder.Services.AddMediatR(typeof(CreateBookCommand).Assembly);

builder.Services.AddMediatR(typeof(CreateCategoryCommand).Assembly);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapIdentityApi<ApplicationUser>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
