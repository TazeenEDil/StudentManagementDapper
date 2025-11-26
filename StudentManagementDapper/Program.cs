using StudentManagementDapper.Data;
using StudentManagementDapper.Interfaces;
using StudentManagementDapper.Repositories;
using StudentManagementDapper.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC
builder.Services.AddControllersWithViews();

// Dapper context + DI
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// Mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
