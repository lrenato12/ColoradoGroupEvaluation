using ColoradoGroupEvaluation.FrontEnd.Services.Config;
using ColoradoGroupEvaluation.FrontEnd.StartupConfiguration;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

builder.Services.AddControllersWithViews();

builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
