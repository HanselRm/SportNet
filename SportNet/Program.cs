using SportNet.Infrastructure.Persistence;
using SportNet.Core.Application;
using SportNet.Infrastructure.Shared;
using SportNet.MiddledWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//usar sesiones
builder.Services.AddSession();

//Dependencias
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddAplicationLayer(builder.Configuration);
builder.Services.AddSharedInfrastructure(builder.Configuration);

builder.Services.AddTransient<ValidateUser, ValidateUser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
