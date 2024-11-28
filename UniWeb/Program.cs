using Microsoft.EntityFrameworkCore;
using UniWeb.Data;
using UniWeb.Services;
using UniWebServer.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<StockServices>();
builder.Services.AddTransient<SuiService>();
builder.Services.AddHttpClient<SuiService>();
builder.Services.AddTransient<BlogService>();

builder.Services.AddDbContextFactory<AppDbContext>((DbContextOptionsBuilder options) =>
options.UseSqlServer(connectionString));

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
