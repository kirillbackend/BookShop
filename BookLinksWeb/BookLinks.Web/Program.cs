using BookLinks.Repositories;
using Microsoft.EntityFrameworkCore;
using BookLinks.Web.Data;
using BookLinks.Service.Services.Interface;
using BookLinks.Service.Services;
using BookLinks.Repositories.Repositories.Interface;
using BookLinks.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();

builder.Services.AddDbContext<BookLinksWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookLinksWebContext") ?? throw new InvalidOperationException("Connection string 'BookLinksWebContext' not found.")));

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
