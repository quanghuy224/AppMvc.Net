using System.Net;
using App.ExtendMethods;
using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// builder.Services.AddTransient(typeof(ILogger<>),typeof(Logger<>));
builder.Services.Configure<RazorViewEngineOptions>(options =>{
    // /View/Controller/Action/cshtml
    // /MyView/Controller/Action/cshtml
    options.ViewLocationFormats.Add("/MyView.{1}/{0}"+RazorViewEngine.ViewExtension);
});

builder.Services.AddSingleton<ProductService>();

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
app.UseStaticFiles();
app.AddStatusCodePage();

app.UseAuthentication();
app.UseAuthorization(); //Code 400-5000

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapGet("/sayhi", async (context) => {
    await context.Response.WriteAsync($"hello ASP.NET MVC {DateTime.Now}");
});    

app.MapRazorPages();

app.Run();
