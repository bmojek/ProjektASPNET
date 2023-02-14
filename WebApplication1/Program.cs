using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KsiazkiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KsiazkiContext") ?? throw new InvalidOperationException("Connection string 'KsiazkiContext' not found.")));
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext1Connection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext1Connection' not found.");

builder.Services.AddDbContext<ApplicationDbContext1>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext1>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();