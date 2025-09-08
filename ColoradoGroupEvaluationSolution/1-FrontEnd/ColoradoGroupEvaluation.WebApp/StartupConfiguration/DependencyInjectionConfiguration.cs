using ColoradoGroupEvaluation.WebApp.Repository;
using ColoradoGroupEvaluation.WebApp.Services.API.Application;

namespace ColoradoGroupEvaluation.WebApp.StartupConfiguration;

public static class DependencyInjectionConfiguration
{
    #region [ ADD DEPENDENCY INJECTION CONFIGURATION ]
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        #region Repositories
        services.AddScoped<IClienteRepository, ClienteRepository>();
        #endregion
        services.AddHttpClient<IApplicationFactory, ApplicationFactory>();
    }
    #endregion
}