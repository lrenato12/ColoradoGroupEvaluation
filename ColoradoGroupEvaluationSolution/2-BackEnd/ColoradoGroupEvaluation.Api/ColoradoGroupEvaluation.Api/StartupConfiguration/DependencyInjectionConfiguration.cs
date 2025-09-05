using ColoradoGroupEvaluation.Core.Managers.Cliente;
using ColoradoGroupEvaluation.Core.Managers.Telefone;
using ColoradoGroupEvaluation.Core.Managers.TipoTelefone;
using ColoradoGroupEvaluation.Infra.Base.Database;
using ColoradoGroupEvaluation.Infra.Base.Database.Uow;
using ColoradoGroupEvaluation.Infra.Cliente;
using ColoradoGroupEvaluation.Infra.Telefone;
using ColoradoGroupEvaluation.Infra.TipoTelefone;

namespace ColoradoGroupEvaluation.Api.StartupConfiguration;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        //#region Managers
        services.AddTransient<IClienteManager, ClienteManager>();
        services.AddTransient<ITelefoneManager, TelefoneManager>();
        services.AddTransient<ITipoTelefoneManager, TipoTelefoneManager>();
        //#endregion

        //#region Providers
        services.AddTransient<IClienteDAL, ClienteDAL>();
        services.AddTransient<ITelefoneDAL, TelefoneDAL>();
        services.AddTransient<ITipoTelefoneDAL, TipoTelefoneDAL>();
        //#endregion

        //#region Database
        services.AddScoped<DbSession>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        //#endregion
    }
}