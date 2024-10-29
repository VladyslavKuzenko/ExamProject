using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using EasyLearn;
using System.Globalization;
using EasyLearn.Data;
using Microsoft.Extensions.Options;
using EasyLearn.SqlLiteDb;
using EasyLearn.MSSqlDb;


var builder = WebApplication.CreateBuilder(args);

var connectionType = builder.Configuration.GetSection("SqlDbType").Value.ToUpper();
string connectionString;
switch (connectionType)
{
    case "SQLLITE":
        connectionString = builder.Configuration.GetConnectionString("SqlLiteContextConnection") ?? throw new InvalidOperationException("Connection string 'SqlLiteContextConnection' not found.");
        // Add services to the container.
        builder.Services.AddDbContext<ApplicationDbContext, SqlLiteDbContext>(options =>
            options.UseSqlite(connectionString));
        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
             .AddEntityFrameworkStores<SqlLiteDbContext>();
        break;
    case "MSSQL":
        connectionString = builder.Configuration.GetConnectionString("MSSqlContextConnection") ?? throw new InvalidOperationException("Connection string 'MSSqlContextConnection' not found.");
        // Add services to the container.
        builder.Services.AddDbContext<ApplicationDbContext, MSSqlDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
          .AddEntityFrameworkStores<MSSqlDbContext>();
        break;
    default:
        break;
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();




builder.Services.AddRazorPages();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options => {
    options.DataAnnotationLocalizerProvider = (type, factory) =>
        factory.Create(typeof(DataAnotationSharedResorce));
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("uk-UA") };
    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    //
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseRequestLocalization(new RequestLocalizationOptions()
{ ApplyCurrentCultureToResponseHeaders = true }
.AddSupportedCultures(new[] { "en-US", "uk-UA" })
.AddSupportedUICultures(new[] { "en-US", "uk-UA" })
.SetDefaultCulture("en-US"));

app.MapRazorPages();

app.MapGet("/", context =>
{
    context.Response.Redirect("/Home/Index"); 
    return Task.CompletedTask;
});
app.MapControllers();


app.Run();