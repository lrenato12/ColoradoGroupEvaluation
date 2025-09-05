using Microsoft.AspNetCore.Http;

namespace ColoradoGroupEvaluation.Core.Base;

public class BaseManager
{
    #region Properties
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region Contructor
    public BaseManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion
}