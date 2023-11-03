using BookLinks.Repositories;
using Microsoft.EntityFrameworkCore;
using BookLinks.Service.Services.Interface;
using BookLinks.Service.Services;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Repositories.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<ILinkService, LinkService>();
builder.Services.AddTransient<ILinkRepository, LinkRepository>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
