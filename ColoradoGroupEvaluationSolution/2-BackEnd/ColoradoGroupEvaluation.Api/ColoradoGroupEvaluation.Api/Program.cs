using ColoradoGroupEvaluation.Api.Middleware;
using ColoradoGroupEvaluation.Api.StartupConfiguration;
using ColoradoGroupEvaluation.Infra.Base.Database;
using ColoradoGroupEvaluation.Shared.Models.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwaggerConfiguration(env);

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
