using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Repositories.Repositories;
using BookLinks.Repositories;
using BookLinks.Service.Services.Interface;
using BookLinks.Service.Services;
using FS.Services.Services.Contracts;
using FS.Services.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<ILinkService, LinkService>();
builder.Services.AddTransient<ILinkRepository, LinkRepository>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
