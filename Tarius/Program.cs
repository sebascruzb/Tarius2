using Tarius.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



// Configuraci�n de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Configuraci�n de la autenticaci�n basada en cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login";
        options.LogoutPath = "/Login/Logout";
        options.AccessDeniedPath = "/Login/AccessDenied";
        options.Cookie.Name = "TariusAuthCookie";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);  // Tiempo de expiraci�n
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.UseAuthentication(); // Aseg�rate de habilitar la autenticaci�n antes de la autorizaci�n
app.UseAuthorization();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();