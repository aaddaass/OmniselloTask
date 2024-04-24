using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OmniselloTask.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using OmniselloTask.Models;

var builder = WebApplication.CreateBuilder(args);

var vegeApiKey = builder.Configuration["VegetableSecretApi"];

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("OmniselloDatabase") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddControllersWithViews();

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //add swagger service

builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "389717730683-voekeirpsuleo994313a7nol9ebbs1d8.apps.googleusercontent.com";
    googleOptions.ClientSecret = "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";
})
    .AddFacebook(options =>
    {
        options.AppId = "1169033231044329";
        options.AppSecret= "752e574b6298be619965e402424c5d1e";
    });


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();   //add swagger in middelware
    app.UseSwaggerUI(); //add swagger in middelware
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();   //add swagger in middelware on hosting environment
    app.UseSwaggerUI(); // is not allowed for security reason!!!!
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
