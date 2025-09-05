using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ColoradoGroupEvaluation.Api.StartupConfiguration;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Grupo Colorado",
                Description = "Grupo Colorado",
                Contact = new OpenApiContact
                {
                    Name = "Grupo Colorado",
                    Email = string.Empty,
                    Url = new Uri("http://www.google.com.br"),
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("../swagger/v1/swagger.json", "Grupo Colorado - V1");

            if (env.IsProduction())
                c.SupportedSubmitMethods(new Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod[] { });
        });
    }
}