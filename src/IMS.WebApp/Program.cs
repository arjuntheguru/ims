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
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.SessionStorage;
using IMS.Infrastructure.Identity.Helpers;
using IMS.Infrastructure.Identity.SeedData;

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
var superAdminModules = SuperAdminModules.GetSuperAdminModules();

builder.Services.AddAuthorizationCore(options =>
{
    foreach (var module in superAdminModules)
    {
        options.AddPolicy($"{module}.Write", policy => policy
        .RequireClaim("Permission", $"{module}.Create")
        .RequireClaim("Permission", $"{module}.Edit"));

        options.AddPolicy($"{module}.View", policy => policy
        .RequireClaim("Permission", $"{module}.View"));

        options.AddPolicy($"{module}.Delete", policy => policy
        .RequireClaim("Permission", $"{module}.Delete"));
    }

});
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<CompanyStateFacade>();
builder.Services.AddScoped<SnackbarHandler>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddHostedService<SeedDataService>();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
