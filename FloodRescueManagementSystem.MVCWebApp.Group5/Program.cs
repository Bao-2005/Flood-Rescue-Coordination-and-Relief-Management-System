using dotenv.net;
using FloodRescueManagementSystem.Repositories.Group5.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

DotEnv.Load();
//var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

//try
//{
//    using var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
//    connection.Open();
//    Console.WriteLine("✅ Kết nối Database thành công!");
//    connection.Close();
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"❌ Kết nối thất bại: {ex.Message}");
//}
var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();

builder.Services.AddDbContext<FloodRescueDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
