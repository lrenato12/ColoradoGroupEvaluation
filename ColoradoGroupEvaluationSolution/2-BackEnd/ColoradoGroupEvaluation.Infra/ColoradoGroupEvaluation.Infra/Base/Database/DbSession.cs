using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using System.Data;

namespace ColoradoGroupEvaluation.Infra.Base.Database;

public sealed class DbSession : IDisposable
{
    #region [ PROPERTIES ]
    private readonly IHostEnvironment _environment;
    private readonly IConfiguration _configuration;
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }
    #endregion

    #region [ CONSTRUCTOR ]
    public DbSession(IHostEnvironment environment, IConfiguration configuration)
    {
        _environment = environment;
        _configuration = configuration;
        Connection = new MySqlConnection(GetConnectionString());
        Connection.Open();
    }
    #endregion

    #region [ DISPOSE ]
    public void Dispose() => Connection?.Dispose();
    #endregion

    #region [ GET CONNECTION STRING ]
    private string GetConnectionString()
    {
        // TODO - Remover a variavel IsDev
        var isDev = _environment.EnvironmentName.Equals("Development");
        var conn = isDev ? _configuration.GetConnectionString("DefaultConnection") : Environment.GetEnvironmentVariable("DefaultConnection");

        return conn ?? string.Empty;
    }
    #endregion
}