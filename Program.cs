using Microsoft.EntityFrameworkCore;
using DockerTestApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var conn = builder.Configuration.GetConnectionString("Default");
if (!string.IsNullOrEmpty(conn) && conn.Contains("Server="))
{
    // assume SQL Server
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(conn));
}
else
{
    // fallback to sqlite
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(conn ?? "Data Source=app.db"));
}

var app = builder.Build();

// Ensure database created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
