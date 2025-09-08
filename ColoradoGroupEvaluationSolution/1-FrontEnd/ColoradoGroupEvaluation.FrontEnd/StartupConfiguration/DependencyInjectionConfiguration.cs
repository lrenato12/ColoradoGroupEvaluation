using ColoradoGroupEvaluation.FrontEnd.Repository;
using ColoradoGroupEvaluation.FrontEnd.Services.API.Application;

namespace ColoradoGroupEvaluation.FrontEnd.StartupConfiguration;

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