using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace ColoradoGroupEvaluation.Infra.Base.Database;

public sealed class DbSession : IDisposable
{
    #region [ PROPERTIES ]
    private readonly IConfiguration _configuration;
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }
    #endregion

    #region [ CONSTRUCTOR ]
    public DbSession(IConfiguration configuration)
    {
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
        return _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }
    #endregion
}