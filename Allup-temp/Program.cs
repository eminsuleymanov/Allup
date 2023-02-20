using Allup_temp.DataAccesLayer;
using Allup_temp.Interfaces;
using Allup_temp.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var conString = builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(conString));

builder.Services.AddScoped<ILayoutService,LayoutService>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
});
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
app.UseSession();
app.UseStaticFiles();

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    
    );

app.Run();

