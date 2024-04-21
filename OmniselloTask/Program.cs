using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OmniselloTask.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

var vegeApiKey = builder.Configuration["VegetableSecretApi"];

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("OmniselloDatabase") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//})
//    .AddCookie()
//    .AddGoogle(GoogleDefaults.AuthenticationScheme, options=>
//    {
//        options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
//        options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
//    });

builder.Services.AddControllersWithViews();

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //add swagger service

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "Authentication:Google:ClientId";
    googleOptions.ClientSecret = "Authentication:Google:ClientSecret";
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
