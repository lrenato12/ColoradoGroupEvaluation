using ColoradoGroupEvaluation.Api.Middleware;
using ColoradoGroupEvaluation.Api.StartupConfiguration;
using ColoradoGroupEvaluation.Infra.Base.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
IWebHostEnvironment env = builder.Environment;

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDependencyInjectionConfiguration();

// 1. LER A CONNECTION STRING DO ARQUIVO APPSETTINGS.JSON
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. ADICIONAR O DBCONTEXT AO CONTAINER DE INJEÇÃO DE DEPENDÊNCIA
//    Isso "ensina" a aplicação a criar e configurar seu DbContext.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    // Agora estamos usando a VARIÁVEL connectionString
    // E detectando a versão do servidor automaticamente
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Adicione também seu repositório para injeção de dependência
//builder.Services.AddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();


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
