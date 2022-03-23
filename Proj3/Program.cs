using Proj3.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();
app.MapControllers();
app.UseRouting();
app.UseStaticFiles();
app.UseCors(builder => {
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
