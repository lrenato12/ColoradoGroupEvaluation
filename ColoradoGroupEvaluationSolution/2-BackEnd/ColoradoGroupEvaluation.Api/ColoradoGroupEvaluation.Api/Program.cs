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

// 2. ADICIONAR O DBCONTEXT AO CONTAINER DE INJE��O DE DEPEND�NCIA
//    Isso "ensina" a aplica��o a criar e configurar seu DbContext.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    // Agora estamos usando a VARI�VEL connectionString
    // E detectando a vers�o do servidor automaticamente
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Adicione tamb�m seu reposit�rio para inje��o de depend�ncia
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
