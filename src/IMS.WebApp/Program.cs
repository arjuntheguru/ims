using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using IMS.Application;
using MudBlazor.Services;
using Microsoft.AspNetCore.Identity;
using IMS.Application.Common.Settings;
using IMS.Infrastructure;
using IMS.Domain.Entites;
using IMS.WebApp;
using IMS.Application.Common.Models;
using AspNetCore.Identity.MongoDB;
using IMS.WebApp.Components.Company;
using Fluxor;
using System.Reflection;
using IMS.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole>(options =>
      {
          var databaseSetting = builder.Configuration.GetSection("DatabaseSetting:MongoDb").Get<DatabaseSettingOption>();
          options.ConnectionString = databaseSetting.ConnectionString;
          options.DatabaseName = databaseSetting.DatabaseName;
          options.UsersCollection = "Users";
          options.RolesCollection = "Roles";
      });
builder.Services.Configure<DatabaseSettingOption>(builder.Configuration.GetSection("DatabaseSetting:MongoDb"));
builder.Services.AddRazorPages();
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor();
builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(Assembly.GetExecutingAssembly());
    options.UseReduxDevTools();
});
builder.Services.AddScoped<CompanyStateFacade>();
builder.Services.AddScoped<SnackbarHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
