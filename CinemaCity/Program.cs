using Microsoft.EntityFrameworkCore;

using CinemaCity.Data;
using CinemaCity.Data.Models;
using CinemaCity.Services;
using CinemaCity.Services.Interfaces;
using CinemaCity.Web.Infrastructure;
using CinemaCity.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;

using static CinemaCity.Common.WebConstants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<CinemaCityContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CinemaCityContext>();
builder.Services.AddControllersWithViews();

builder.Services.Configure<MovieSettings>(builder.Configuration.GetSection("MovieSettings"));
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICinemaService, CinemaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.SeedAdministrator(DevelopmentAdminEmail);
    app.UseMigrationsEndPoint();
}
else
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

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "areas",
        pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
	);
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}"
	);
});

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
