using ColoradoGroupEvaluation.Infra.Base.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ColoradoGroupEvaluation.Infra.Base;

public class BaseDAL
{
    #region [ PROPERTIES ]
    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _environment;
    public readonly IEnumerable<string> _userRoles;
    public readonly DbSession _dbSession;
    #endregion

    #region [ CONSTRUCTOR ]
    public BaseDAL(IConfiguration configuration, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, DbSession dbSession = null)
    {
        _configuration = configuration;
        _environment = environment;
        _dbSession = dbSession;
    }
    #endregion
}