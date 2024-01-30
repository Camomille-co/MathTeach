using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MathDbContext>(options => options.UseSqlServer(@"Server=DESKTOP-RR0CBRF;Database=MathTeach;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=True", b => b.MigrationsAssembly("DataLayer")));

//var provider = builder.Services.BuildServiceProvider();
//var configuration = provider.GetRequiredService<IConfiguration>();
//builder.Services.AddDbContext<MathDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("myconn")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
