using Microsoft.EntityFrameworkCore;
using MvcCodeFirst.Models.Context;
using MvcCodeFirst.Repositories.Abstracts;
using MvcCodeFirst.Repositories.Concretes;

var builder = WebApplication.CreateBuilder(args);
//Services
builder.Services.AddControllersWithViews();

//AddDbContext
builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MySqlConnection")));


//AppUser Service
builder.Services.AddScoped<IAppUserRepository, AppUserService>();
builder.Services.AddScoped<IProductRepository,ProductService>();


//Applications
var app = builder.Build();


//Url tanýmlamalarý
app.UseRouting();


//wwwroot eriþime izin verilmesi
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    //https://localhost:7209/Home/Index
});

app.Run();