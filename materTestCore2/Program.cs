using Semiodesk.Trinity;
using System.Reflection;
using materTestCore2.Models.EGovModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using VDS.RDF.Query.Algebra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "MyAppCookie";
        options.LoginPath = "/Account/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<graphContext>();
builder.Services.AddMvc();
//OntologyDiscovery.AddAssembly(Assembly.GetExecutingAssembly());
//MappingDiscovery.RegisterCallingAssembly();

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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");
OntologyDiscovery.AddAssembly(Assembly.GetExecutingAssembly());
MappingDiscovery.RegisterCallingAssembly();
app.Run();
